using Core.Entities;
using Core.Interfaces;
using Dapper;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DAL.Services
{
    public class DbSynchronizer<T> : IDbSynchronizer<T> where T : BaseEntity
    {        
        private readonly IDbConnection _connection;
        private string[] _filesChanged;
        public DbSynchronizer(IOptions<LegacyDatabaseSettings> options)
        {            
            _connection = new OleDbConnection(options.Value.ToString());
        }
        public void GetFilesChanged()
        {
             //TODO:Get list of files changed from git repository

        }
        //?How do I test this?
        public void SyncChanges()
        {
            var updateQuery = new StringBuilder();
            for (int i = 0; i < _filesChanged.Length; ++i){
                string tableName = _filesChanged[i].Substring(_filesChanged[i].LastIndexOf("/"));
                var diff = DbfComparers.DbfComparer.GetDiff(tableName, _filesChanged[i]).ToArray();
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
        }        
    }
}
