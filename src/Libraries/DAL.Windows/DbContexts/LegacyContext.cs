using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Advantage.Data.Provider;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DAL.Windows
{
    /// <summary>
    /// Context to handle database of legacy system
    /// </summary>
    //TODO: you probably don't need the T parameter, change it to a object instead and run the tests
    public class LegacyContext
    {
        private readonly IDbConnection _connection;        
        public LegacyContext(string connectionString)
        {
            _connection = new AdsConnection(connectionString);            
        }
        public long Create(object entry)
        {
            _connection.Open();
            var result = _connection.Insert(entry);
            _connection.Close();
            return result;
        }
        public T GetBy<T>(int id) where T : class
        {
            _connection.Open();
            var result = _connection.Get<T>(id);
            _connection.Close();
            return result;
        }
        public T GetBy<T>(string id) where T : class
        {
            _connection.Open();
            var result = _connection.Get<T>(id);
            _connection.Close();
            return result;
        }
        public bool Update(object entry)
        {
            _connection.Open();
            var result = _connection.Update(entry);
            _connection.Close();
            return result;
        }
        public bool Delete(object entry)
        {
            _connection.Open();
            var result = _connection.Delete(entry);
            _connection.Close();
            return result;
        }
        public T RawQuery<T>(string sql) 
        {
            _connection.Open();
            var result = _connection.QueryFirstOrDefault<T>(sql);
            _connection.Close();
            return result;
        }        
        public IEnumerable<T> MultipleFromRawQuery<T>(string sql)
        {
            _connection.Open();
            var result = _connection.Query<T>(sql);
            _connection.Close();
            return result;
        }
        public async Task<IEnumerable<T>> MultipleFromRawQueryAsync<T>(string query)
        {
            _connection.Open();
            var result = await _connection.QueryAsync<T>(query);
            _connection.Close();
            return result;
        }
        public void Command(string query,object entity)
        {
            _connection.Open();            
            _connection.Execute(query,entity);            
            _connection.Close();
        }        
    }   
}