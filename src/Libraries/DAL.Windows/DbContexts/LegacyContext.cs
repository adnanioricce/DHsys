using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using DAL.Windows.Models;
using Dapper;
using Infrastructure.Windows.Settings;
using Microsoft.Extensions.Options;

namespace DAL.Windows
{
    /// <summary>
    /// Context to handle database of legacy system
    /// </summary>
    //TODO: you probably don't need the T parameter, change it to a object instead and run the tests
    public class LegacyContext<T>
    {
        private readonly IDbConnection _connection;

        public EntityField[] Fields { get; } = typeof(T)
            .GetProperties()
            .Select(x => new EntityField {
                FieldName = x.Name,
                Value = null
            }).ToArray();

        public LegacyContext(IOptions<LegacyDatabaseSettings> options)
        {
            _connection = new OleDbConnection(options.Value.ToString());                                     
            
        }
        public T RawQuery(string sql)
        {
            _connection.Open();
            var result = _connection.QueryFirstOrDefault<T>(sql);
            _connection.Close();
            return result;
        }        
        public IEnumerable<T> MultipleFromRawQuery(string sql)
        {
            _connection.Open();
            var result = _connection.Query<T>(sql);
            _connection.Close();
            return result;
        }
        public async Task<IEnumerable<T>> MultipleFromRawQueryAsync(string query)
        {
            _connection.Open();
            var result = await _connection.QueryAsync<T>(query);
            _connection.Close();
            return result;
        }
        public void Command(string query,T entity)
        {
            _connection.Open();            
            _connection.Execute(query,entity);            
            _connection.Close();
        }        
    }   
}