using Core.Interfaces.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
namespace DAL.Repositories
{
    //TODO: Define a ReadOnlyRepository interface
    public class ReadOnlyRepository<T> : IReadOnlyAsyncRepository<T>
    {
        protected readonly IDbConnection _conn;
        public ReadOnlyRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            _conn.Open();
            var listResult = _conn.QueryAsync<T>($"SELECT * FROM {typeof(T)}");
            _conn.Close();
            return listResult;
        }

        public Task<T> GetByAsync(int id)
        {
            _conn.Open();
            var entity = _conn.QuerySingleAsync<T>($@"SELECT * FROM {typeof(T).Name} WHERE ""Id"" = @Id",id);
            _conn.Close();
            return entity;
        }

        public Task<IEnumerable<T>> QueryListAsync(string query)
        {
            _conn.Open();
            var listResult = _conn.QueryAsync<T>(query);
            _conn.Close();
            return listResult;
        }

        public Task<T> QuerySingleAsync(string query)
        {
            _conn.Open();
            var entity = _conn.QuerySingleAsync<T>(query);
            _conn.Close();
            return entity;
        }
    }
}
