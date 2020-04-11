using Core.Entities;
using Core.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class DbSynchronizer : IDbSynchronizer
    {        
        private readonly IDbConnection _connection;
        private List<string> _dbfFilesChanged;
        private List<string> _txtFilesChanged;
        private int lastCommitId;
        private bool _isDirty = false;

        public bool IsDirty => _isDirty;

        public DbSynchronizer(IOptions<LegacyDatabaseSettings> options)
        {            
            _connection = new OleDbConnection(options.Value.ToString());            
        }                     
        //?How do I test this?
        public string GenerateUpdateScript()
        {
            return "";
        }
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
