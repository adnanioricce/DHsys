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
using Infrastructure.Windows.Extensions;
using Microsoft.Data.Sqlite;
using Infrastructure.Windows.Models;
using Legacy.Entities;
using Legacy.Models.Sync;
using Legacy.Interfaces.Sync;
using Legacy.Models.Dbf;
using Application.Windows.Extensions;
using Infrastructure.Logging;

namespace Application.Windows.Services.Sync
{
    public class LegacyDbSynchronizer : ILegacyDbSynchronizer
    {        
        private readonly IDbConnection _sourceDbConnection;        
        private readonly IDbConnection _localDbConnection;
        private readonly DbDataAdapter _localDataAdapter;
        private readonly DataSet _dataSet = new DataSet();
        private readonly List<string> _dbfFilesChanged;
        private static MethodInfo Converter;
        private readonly Dictionary<string,Type> LegacyTypes = new Dictionary<string, Type>();
        public LegacyDbSynchronizer(ConnectionResolver connectionResolver)
        {                                             
            LegacyTypes = Assembly.Load(typeof(Core.Core).Assembly.FullName)
                .GetTypes()
                .Where(t => t.Namespace == typeof(ILegacy).Namespace && t.IsClass)                
                .ToDictionary(v => v.Name);
            _localDbConnection = connectionResolver("local");
            _sourceDbConnection = connectionResolver("source");
            _localDataAdapter = _localDbConnection.GetDataAdapter();            
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
                    string ColumnsAndValues = string.Join(",", record.Value.ColumsChanged.Select(column => column.WriteUpdateSetToCorrectSqlType()));
                    sqlCommandBuilder.Append($"UPDATE {type.Name} SET LastUpdatedOn = CURRENT_TIMESTAMP,{ColumnsAndValues} WHERE Id = {record.Value.RecordIndex};");
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
                string values = string.Join(',', fields.Select(f => RecordColumn.WriteInsertValuesToCorrectSqlType(f.Value)));
                string columnNames = string.Join(",", fields.Select(f => f.FieldName));
                sqlCommandBuilder.Append($"INSERT INTO {type.Name.ToUpper()}(UniqueCode,CreatedAt,LastUpdatedOn,{columnNames}) VALUES('{fields.FirstOrDefault().Value}',CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,{values});");
            }
            return sqlCommandBuilder.ToString();
        }
             
        
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
        /// <summary>
        /// Sync data From Source database (legacy system) To Local (current system) database
        /// </summary>
        /// <param name="sourceDatabaseFolder">the folder with the database(.dbf) files</param>
        /// <returns>a number with the affected rows</returns>
        public int SyncSourceDatabaseWithLocalDatabase(string sourceDatabaseFolder)
        {
            //?the existence of this method is worthed?
            var changes = MapDbfsToDataset(Directory.GetFiles(sourceDatabaseFolder,"*.DBF"),_sourceDbConnection);
            try {
                string queryTemplate = "SELECT * FROM {0} WHERE UniqueCode = '{1}';";
                var commandBuilder = _localDbConnection.GetCommandBuilder(_localDataAdapter);                
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
                            var values = string.Join(',',changes.Tables[i].Rows[j].ItemArray.Select(RecordColumn.WriteInsertValuesToCorrectSqlType));                            
                            queryBuilder.AppendLine($"INSERT INTO {changes.Tables[i].TableName}(LastUpdatedOn,CreatedAt,UniqueCode,{fields}) VALUES(CURRENT_TIMESTAMP,CURRENT_TIMESTAMP,{changes.Tables[i].Rows[j].ItemArray[0]},{values});");
                            continue;
                        }            
                        string columnsToUpdate = string.Join(',', changes.Tables[i].Rows[j].ItemArray
                            .Select(RecordColumn.WriteInsertValuesToCorrectSqlType)
                            .Select((item,index) => $"{columns[index]}={item}"));                        
                        queryBuilder.AppendLine($"UPDATE {changes.Tables[i].TableName} SET LastUpdatedOn=CURRENT_TIMESTAMP,{columnsToUpdate} WHERE UniqueCode = {queryResult};");                                                        
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
            var tableNamesAndFilenames = files.Where(f => (f.Contains(".DBF") || f.Contains(".dbf")))                                               
                                              .Select(ConvertFilenameToSelectQuery)
                                              .ToList();                             
            dbConnection.Open();                     
            for (int i = 0; i < tableNamesAndFilenames.Count; i++)
            {
                var adapter = new OleDbDataAdapter(tableNamesAndFilenames[i].Query,(OleDbConnection)dbConnection);                                                
                adapter.TableMappings.Add(tableNamesAndFilenames[i].TableName,tableNamesAndFilenames[i].TableName);
                try{                    
                    adapter.Fill(dataSet);
                    dataSet.Tables[i].TableName = tableNamesAndFilenames[i].TableName;                    
                }catch(Exception ex){
                    AppLogger.Log.Error("Error occurred whem trying to map legacy databases files to DataAdapter objects, with the given exception. @ex", ex);                   
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
