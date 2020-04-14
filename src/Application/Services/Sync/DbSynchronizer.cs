using Core.Entities;
using Core.Interfaces;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using DAL;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.Services
{
    public class DbSynchronizer : IDbSynchronizer
    {        
        private readonly IDbConnection _connection;
        private readonly IServiceProvider _serviceProvider;
        private List<string> _dbfFilesChanged;
        private List<string> _txtFilesChanged;                

        public DbSynchronizer(IOptions<LegacyDatabaseSettings> options)
        {
            //_connection = new OleDbConnection(options.Value.ToString());                                  
        }        
        //?How do I test this?
        
        public string GenerateSyncScriptForEntity(SyncDatabaseRequest request)
        {
            var commandBuilder = new StringBuilder();
            string className = char.ToUpper(request.TableName[0]) + request.TableName.ToLower().Substring(1,request.TableName.Length-1);
            var type = Assembly.Load("Core").GetTypes().Where(t => t.Name == className).FirstOrDefault();          
            foreach(var record in request.RecordDiffs) {                
                if (record.Value.IsNew)
                {
                    var entity = Convert.ChangeType(record.Value.RecordValue, type);
                    var fields = entity.GetType()
                        .GetProperties(System.Reflection.BindingFlags.DeclaredOnly)
                        .Select(p => new
                        {
                            FieldName = p.Name,
                            Value = p.GetValue(p)
                        });
                    string values = string.Join(',', fields.Select(f => f.Value));
                    commandBuilder.Append($"INSERT INTO {type.Name.ToUpper()} VALUES({values});");
                }                
                //I would update only the columns changed, but I received only one column, maybe I receive 12 columns changed                    
                string ColumnsAndValues = string.Join(",", record.Value.ColumsChanged.Select(WriteUpdateSetToCorrectSqlType));
                commandBuilder.Append($"UPDATE {type.Name} SET {ColumnsAndValues} WHERE Id = {record.Value.RecordIndex};");
            }
            return commandBuilder.ToString();
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
        public void SyncDbfChanges()
        {            
            if (_dbfFilesChanged.Count == 0) return;

            var updateQuery = new StringBuilder();
            for (int i = 0; i < _dbfFilesChanged.Count; ++i) {
                string tableName = _dbfFilesChanged[i].Substring(_dbfFilesChanged[i].LastIndexOf("/"));
                var diff = DbfComparers.DbfComparer.GetDiff(tableName, _dbfFilesChanged[i]).ToArray();
                var columns = diff.Select(d => d.Columns.Select(c => c.ColumnName)).ToArray();
                for(int j = 0;j < diff.Length; ++j) {                    
                    updateQuery.Append($"UPDATE {tableName} SET ");
                    var columnCount = columns.Count();
                    for (int k = 0; k < columnCount; ++k) {
                        updateQuery.Append($"{diff[j].Columns[k].ColumnName}={diff[j].Columns[k].NewValue}");
                        if(columnCount == k) {
                            updateQuery.Append($"WHERE Id = {diff[j].Index};");
                        }
                        else {
                            updateQuery.Append(",");
                        }
                    }
                    try {
                        _connection.Open();
                        var command = _connection.CreateCommand();
                        command.CommandText = updateQuery.ToString();
                        command.ExecuteNonQuery();
                        _connection.Close();
                        updateQuery.Clear();
                    }
                    catch(OleDbException ex)
                    {
                        //TODO:Create log service
                        Console.Out.WriteLine(ex.ToString());
                        throw;
                    }
                }
            }
            _dbfFilesChanged.Clear();
        }               
    }
}
