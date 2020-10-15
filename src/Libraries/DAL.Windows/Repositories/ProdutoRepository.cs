using DAL.Windows.Repositories;
using Legacy.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Windows
{
    //TODO:Remove the type parameter
    public class ProdutoRepository<T> : ILegacyRepository<T> where T : Produto
    {
        private readonly LegacyContext _context;
        
        public ProdutoRepository(LegacyContext context)
        {
            _context = context;            
        }
        public long Add(T entry)
        {
            return _context.Create(entry);
        }
        public bool Update(T entry)
        {
            return _context.Update(entry);
        }
        public bool Delete(T entry)
        {
            return _context.Delete(entry);
        }
        public void Command(string query, T entity)
        {
            _context.Command(query, entity);
        }

        public T GetById(int id)
        {
            return _context.GetBy<T>(id);
        }

        public T GetById(string id)
        {
            return _context.RawQuery<T>($"SELECT * FROM {typeof(T).Name} WHERE prcodi = {id}");
        }

        public IEnumerable<T> MultipleFromRawSqlQuery(string query)
        {
            return _context.MultipleFromRawQuery<T>(query);
        }        
        public async Task<IEnumerable<T>> MultipleFromRawSqlQueryAsync(string query)
        {
            return await _context.MultipleFromRawQueryAsync<T>(query);
        }
        public IQueryable<T> QueryableByRawQuery(string query)
        {
            return _context.MultipleFromRawQuery<T>(query).AsQueryable();
        }
        public IQueryable<T> QueryableByRawQuery()
        {
            return _context.MultipleFromRawQuery<T>($"SELECT * FROM {typeof(T).Name}").AsQueryable();
        }

        public T RawSqlQuery(string query)
        {
            return _context.RawQuery<T>(query);
        }
       
    }
}