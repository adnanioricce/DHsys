using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Options;

namespace DAL
{
    /// <summary>
    /// Context to handle database of legacy system
    /// </summary>
    public class LegacyContext<T>
    {
        private readonly IDbConnection _connection;        
        private readonly LegacyDatabaseModel _dbParameters;
        private readonly EntityField[] _fields = typeof(T).GetProperties().Select(x => new EntityField{
                FieldName = x.Name,
                Value = null
            }).ToArray();
        public LegacyContext(IOptions<LegacyDatabaseModel> options)
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
        public IEnumerable<T> MultipleRawQuery(string sql)
        {
            _connection.Open();
            var result = _connection.Query<T>(sql);
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