using Core.Interfaces.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Linq;

namespace DAL.Repositories
{
    //TODO: Define a ReadOnlyRepository interface
    public class ReadOnlyRepository<T> : IReadOnlyAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DHsysContext _context;
        protected readonly IDbConnection _conn;
        public ReadOnlyRepository(DHsysContext context)
        {
            _context = context;
            _conn = _context.Database.GetDbConnection();
        }
        public IEnumerable<T> Stream()
        {
            var query = _context.Set<T>().ToQueryString();
            _conn.Open();
            foreach (var result in _conn.Query<T>(query,buffered:false))
            {
                yield return result;
            }
            _conn.Close();
        }
        public Task<IEnumerable<T>> GetAllAsync()
        {
            _conn.Open();            
            var listResult = _conn.QueryAsync<T>(_context.Set<T>().ToQueryString());
            _conn.Close();
            return listResult;
        }

        public Task<T> GetByAsync(int id)
        {
            _conn.Open();
            var query = _context.Set<T>().AsQueryable()
                             .Where(e => e.Id == id)
                             .ToQueryString();
            var entity = _conn.QuerySingleAsync<T>(query);
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

        public IAsyncEnumerable<T> ListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
