using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class DbSynchronizer<T> : IDbSynchronizer<T> where T : BaseEntity
    {        
        private readonly IDbConnection _connection;
        private readonly IGitRepositoryManager _gitRepositoryManager;
        private List<string> _dbfFilesChanged;
        private List<string> _txtFilesChanged;
        public DbSynchronizer(IOptions<LegacyDatabaseSettings> options,IGitRepositoryManager gitRepositoryManager)
        {            
            _connection = new OleDbConnection(options.Value.ToString());
            _gitRepositoryManager = gitRepositoryManager;
        }
        public IEnumerable<string> GetFilesChanged()
        {
            //TODO:Get list of files changed from git repository
            var status = _gitRepositoryManager.GetStatus();
            if (status.HasChanged)
            {
                return status.Paths;
            }
            return null;
        }        
        public void AddFileChanged()
        {
            var files = GetFilesChanged();
            if(files is null)
            {
                return;
            }
            var dbfFiles = files.Where(f => f.EndsWith(".DBF"));
            var txtFiles = files.Where(f => f.EndsWith(".txt"));
            if (!(dbfFiles is null)) {
                _dbfFilesChanged.AddRange(dbfFiles);
            }
            if (!(txtFiles is null)) {
                _txtFilesChanged.AddRange(txtFiles);
            }
        }
        //?How do I test this?
        public void SyncChanges()
        {            
            if (_dbfFilesChanged.Count == 0) return;

            var updateQuery = new StringBuilder();
            for (int i = 0; i < _dbfFilesChanged.Count; ++i){
                string tableName = _dbfFilesChanged[i].Substring(_dbfFilesChanged[i].LastIndexOf("/"));
                var diff = DbfComparers.DbfComparer.GetDiff(tableName, _dbfFilesChanged[i]).ToArray();
                var columns = diff.Select(d => d.Columns.Select(c => c.ColumnName)).ToArray();
                for(int j = 0;j < diff.Length; ++j)
                {                    
                    updateQuery.Append($"UPDATE {tableName} SET ");
                    var columnCount = columns.Count();
                    for (int k = 0; k < columnCount; ++k)
                    {
                        updateQuery.Append($"{diff[j].Columns[k].ColumnName}={diff[j].Columns[k].NewValue}");
                        if(columnCount == k)
                        {
                            updateQuery.Append($"WHERE Id = {diff[j].Index};");
                        }
                        else
                        {
                            updateQuery.Append(",");
                        }
                    }
                    try
                    {
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
