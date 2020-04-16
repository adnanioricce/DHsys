using Core.Entities;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using DAL;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Services
{
    public class DbSynchronizer : IDbSynchronizer
    {        
        private readonly IDbConnection _connection;        
        private List<string> _dbfFilesChanged;
        private static MethodInfo Converter;
        private Dictionary<string,Type> LegacyTypes = new Dictionary<string, Type>();
        public DbSynchronizer(IDbConnection dbConnection)
        {                                             
            LegacyTypes = Assembly.Load(typeof(Core.Core).Assembly.FullName)
                .GetTypes()
                .Where(t => t.Namespace == typeof(ILegacyScaffold).Namespace && t.IsClass)                
                .ToDictionary(v => v.Name);
            _connection = dbConnection;
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
            "DateTime" => $"{Convert.ToDateTime(value)}",
            "Double" => $"{Convert.ToDouble(value)}",
            _ => $"'{value}'"
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
