using System.Net;
using Core.Entities;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Models.Dbf;
using Core.Models.ApplicationResources.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Data.SQLite;
using Core.Extensions;
using Infrastructure.Extensions;
using Infrastructure.Models;

namespace Application.Services
{
    public class DbSynchronizer : IDbSynchronizer
    {        
        private readonly IDbConnection _sourceDbConnection;        
        private readonly IDbConnection _localDbConnection;
        private readonly DbDataAdapter _localDataAdapter;
        private readonly DataSet _dataSet = new DataSet();
        private readonly List<string> _dbfFilesChanged;
        private static MethodInfo Converter;
        private readonly Dictionary<string,Type> LegacyTypes = new Dictionary<string, Type>();
        public DbSynchronizer(ConnectionResolver connectionResolver)
        {                                             
            LegacyTypes = Assembly.Load(typeof(Core.Core).Assembly.FullName)
                .GetTypes()
                .Where(t => t.Namespace == typeof(ILegacyScaffold).Namespace && t.IsClass)                
                .ToDictionary(v => v.Name);
            _localDbConnection = connectionResolver("local");
            _sourceDbConnection = connectionResolver("source");
            _localDataAdapter = GetDataAdapter(_localDbConnection);            
            var tables = LegacyTypes.Select(lt => new DataTableMapping(lt.Key, lt.Key))
                                                               .ToArray();            
             
            _localDataAdapter.TableMappings.AddRange(tables);
            var command = _localDbConnection.CreateCommand();
            command.CommandText = string.Join(';',tables.Where(t => !string.IsNullOrEmpty(t.DataSetTable)).Select(t => $"SELECT * FROM {t.DataSetTable}"));
            _localDataAdapter.SelectCommand = (DbCommand)command;
            _localDataAdapter.Fill(_dataSet);
            for(int i = 0; i < _dataSet.Tables.Count;++i){
                _dataSet.Tables[i].TableName = tables[i].DataSetTable;
            }
        }                
        
        public string GenerateSyncScriptForEntity(SyncDatabaseRequest request)
        {
            var sqlCommandBuilder = new StringBuilder();
            string className = Path.GetFileNameWithoutExtension(char.ToUpper(request.TableName[0]) + request.TableName
                .ToLower()
                .Substring(1,request.TableName.Length-1));            
            var type = LegacyTypes[className];
            Converter = this.GetType().GetMethod("CastObject").MakeGenericMethod(type);                        
            foreach (var record in request.RecordDiffs) {                
                if (!record.Value.IsNew){                                     
                    string ColumnsAndValues = string.Join(",", record.Value.ColumsChanged.Select(WriteUpdateSetToCorrectSqlType));
                    sqlCommandBuilder.Append($"UPDATE {type.Name} SET {ColumnsAndValues} WHERE Id = {record.Value.RecordIndex};");
                    continue;
                }                
                var entity = Converter.Invoke(null, new object[] { record.Value.RecordValue });
                var fields = entity.GetType()
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => new
                    {
                        FieldName = p.Name,
                        Value = p.GetValue(entity)
                    });
                string values = string.Join(',', fields.Select(f => WriteInsertValuesToCorrectSqlType(f.Value)));
                string columnNames = string.Join(",", fields.Select(f => f.FieldName));
                sqlCommandBuilder.Append($"INSERT INTO {type.Name.ToUpper()}({columnNames}) VALUES({values});");
            }
            return sqlCommandBuilder.ToString();
        }
             
        public string WriteUpdateSetToCorrectSqlType(RecordColumn column) => column.Value.GetType().Name switch
        {
            "Int32" => $"{column.ColumnName}={Convert.ToInt32(column.Value)}",
            "Int64" => $"{column.ColumnName}={Convert.ToInt64(column.Value)}",
            "Int16" => $"{column.ColumnName}={Convert.ToInt16(column.Value)}",
            "Byte" => $"{column.ColumnName}={Convert.ToByte(column.Value)}",
            "Decimal" => $"{column.ColumnName}={Convert.ToDecimal(column.Value)}",
            "DateTime" => $"{column.ColumnName}={Convert.ToDateTime(column.Value)}",
            "Double" => $"{column.ColumnName}={Convert.ToDouble(column.Value)}",
            _ => $"{column.ColumnName}='{column.Value}'"
        };
        public string WriteInsertValuesToCorrectSqlType(object value) => value.GetType().Name switch 
        {
            "Int32" => $"{Convert.ToInt32(value)}",
            "Int64" => $"{Convert.ToInt64(value)}",
            "Int16" => $"{Convert.ToInt16(value)}",
            "Byte" => $"{Convert.ToByte(value)}",
            "Decimal" => $"{Convert.ToDecimal(value)}",
            "DateTime" => $"{Convert.ToDateTime(value).ToShortDateString()}",
            "Double" => $"{Convert.ToDouble(value.ToString().Replace(',','.'))}",
            "Single" => $"{Convert.ToSingle(value.ToString().Replace(',','.'))}",
            "String" => $"'{value.ToString().Replace("'"," ")}'",
            _ => "NULL"
        };
        public void SyncDbfChanges()
        {            
            if (_dbfFilesChanged.Count == 0) return;            
            for (int i = 0; i < _dbfFilesChanged.Count; ++i) {
                SyncDbfChanges(_dbfFilesChanged[i]);
            }
            _dbfFilesChanged.Clear();
        }
        public void SyncDbfChanges(string dbfFilePath)
        {
            var updateQuery = new StringBuilder();
            string tableName = dbfFilePath.Substring(dbfFilePath.LastIndexOf("/"));
            var diff = DbfDiffExtensions.GetDiff(tableName, dbfFilePath).ToArray();        
            //TODO:Adapt this to deleted files    
            var rowsChanged = diff
                .Where(d => d.State == DiffState.Modified || d.State == DiffState.Added)
                .Select(d => new
                {
                    d.RecordIndex,
                    Columns =  d.ColumnsChanged.Select(c => new
                    {
                        c.Field.Name,
                        c.NewValue
                    })
                })
                .ToArray();            
            for (int j = 0; j < diff.Length; ++j){
                updateQuery.Append($"UPDATE {tableName} SET ");
                var columnCount = rowsChanged.Count();                
                string updateColumnsAndValues = string.Join(",",rowsChanged[j].Columns.Select(c => $"{c.Name}={c.NewValue}"));
                updateQuery.Append(updateColumnsAndValues);
                updateQuery.Append($"WHERE Id = {rowsChanged[j].RecordIndex};");
                try {
                    _sourceDbConnection.Open();
                    var command = _sourceDbConnection.CreateCommand();
                    command.CommandText = updateQuery.ToString();
                    command.ExecuteNonQuery();
                    _sourceDbConnection.Close();
                    updateQuery.Clear();
                }
                catch (OleDbException ex)
                {
                    //TODO:Create log service
                    Console.Out.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
        public int SyncSourceDatabaseWithLocalDatabase(string sourceDatabaseFolder)
        {
            //?the existence of this method is worted?
            var changes = MapDbfsToDataset(Directory.GetFiles(sourceDatabaseFolder,"*.DBF"),_sourceDbConnection);
            try
            {
                string queryTemplate = "SELECT * FROM {0} WHERE UniqueCode = {1};";
                var commandBuilder = GetCommandBuilder(_localDbConnection,_localDataAdapter);                
                var queryBuilder = new StringBuilder();                                                
                _localDbConnection.Open();
                var queryCommand = _localDbConnection.CreateCommand();                
                for(int i = 0; i < changes.Tables.Count;++i){
                    var columns = new List<string>();
                    for(int k = 0;k < changes.Tables[i].Columns.Count;++k){
                        columns.Add(changes.Tables[i].Columns[k].ColumnName);
                    }
                    var fields = string.Join(',',columns);
                    for(int j = 0;j < changes.Tables[i].Rows.Count;++j){                        
                        string query = string.Format(queryTemplate,changes.Tables[i].TableName,changes.Tables[i].Rows[j].ItemArray[0]);
                        queryCommand.CommandText = query;
                        var queryResult = queryCommand.ExecuteScalar();
                        if(IsQueryResultNull(queryResult)){
                            var values = string.Join(',',changes.Tables[i].Rows[j].ItemArray.Select(WriteInsertValuesToCorrectSqlType));                            
                            queryBuilder.AppendLine($"INSERT INTO {changes.Tables[i].TableName}(UniqueCode,{fields}) VALUES({changes.Tables[i].Rows[j].ItemArray[0]},{values});");
                            continue;
                        }            
                        string columnsToUpdate = string.Join(',', changes.Tables[i].Rows[j].ItemArray
                            .Select(WriteInsertValuesToCorrectSqlType)
                            .Select((item,index) => $"{columns[index]}={item}"));                        
                        queryBuilder.AppendLine($"UPDATE {changes.Tables[i].TableName} SET {columnsToUpdate} WHERE UniqueCode = {queryResult};");                                                        
                    }                    
                }                    
                var command = _localDbConnection.CreateCommand();    
                command.CommandText = queryBuilder.ToString();
                try{
                    int result = command.ExecuteNonQuery();
                    _localDbConnection.Close();                                
                    return result;
                }catch(Exception ex){
                    //TODO:
                    return 0;
                }
                
                
            }catch(DBConcurrencyException ex)
            {
                //TODO:log exception
                throw;
            }            
        }
        private bool IsQueryResultNull(object record)
        {
            if(!record.IsNumber()){
                return string.IsNullOrEmpty((string)record);
            }
            return (int)record  < 0;
        }
        public DataSet GetChangesBetweenDatabases(string sourceFolderPath)
        {                        
            var localDataSet = new DataSet();                                                                  
            var sourceDataSet = MapDbfsToDataset(Directory.GetFiles(sourceFolderPath,"*.DBF"),_sourceDbConnection);
            _localDbConnection.Open();
            _localDataAdapter.Fill(localDataSet);
            _localDbConnection.Close();
            localDataSet.Merge(sourceDataSet);            
            if(!localDataSet.HasChanges()) return localDataSet;
            var changes = localDataSet.GetChanges();             
            return changes;
        }
        public DataSet MapDbfsToDataset(string[] files,IDbConnection dbConnection)
        {            
            var dataSet = new DataSet();                        
            // var adapter = GetDataAdapter(dbConnection);
            // I need to fill the dataset with the table values, but I need the name of the tables to index the files that I am receiving
            var tableNamesAndFilenames = files.Where(f => (f.Contains(".DBF") || f.Contains(".dbf")))                                               
                                              .Select(ConvertFilenameToSelectQuery)
                                              .ToList();                             
            dbConnection.Open();                     
            for (int i = 0; i < tableNamesAndFilenames.Count; i++)
            {
                var adapter = new OleDbDataAdapter(tableNamesAndFilenames[i].Query,(OleDbConnection)dbConnection);                                                
                adapter.TableMappings.Add(tableNamesAndFilenames[i].TableName,tableNamesAndFilenames[i].TableName);
                try{
                    // adapter.TableMappings.
                    adapter.Fill(dataSet);
                    dataSet.Tables[i].TableName = tableNamesAndFilenames[i].TableName;                    
                }catch(Exception ex){
                    //TODO:
                }                                
            }                           
            
            dbConnection.Close();
            return dataSet;
        }
        public (string Query,string TableName) ConvertFilenameToSelectQuery(string filepath)
        {
            string filename = Path.GetFileNameWithoutExtension(filepath);                                                
            string tableName = char.ToUpper(filename[0]) + filename.Substring(1);
            return (Query:$"SELECT * FROM {tableName.ToUpper()}.DBF",TableName:tableName);
            
        }        
        private DbDataAdapter GetDataAdapter(IDbConnection dbConnection)
        {
            if(dbConnection is SQLiteConnection) return new SQLiteDataAdapter();
            if(dbConnection is OleDbConnection) return new OleDbDataAdapter();
            return new System.Data.SQLite.SQLiteDataAdapter();            
        }
        private DbCommandBuilder GetCommandBuilder(IDbConnection dbConnection,DbDataAdapter adapter)
        {
            
            if(dbConnection is SQLiteConnection) return new SQLiteCommandBuilder((SQLiteDataAdapter)adapter);
            if(dbConnection is OleDbConnection) return new OleDbCommandBuilder((OleDbDataAdapter)adapter);
            return new System.Data.SQLite.SQLiteCommandBuilder((SQLiteDataAdapter)adapter);
        }
        public static T CastObject<T>(object input)
        {            
            if(input is JObject)
            {
                return (T)(JsonSerializer.Deserialize((input as JObject).ToString(), typeof(T)));
            }            
            return (T)input;
        }
        
    }
}
