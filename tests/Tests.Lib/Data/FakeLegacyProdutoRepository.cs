using System.Collections.Generic;
using System.Linq;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;

namespace Tests.Lib.Data
{
    public class FakeLegacyProdutoRepository : ILegacyRepository<Produto>
    {
        public FakeLegacyProdutoRepository()
        {
            
        }
        public FakeLegacyProdutoRepository(IEnumerable<Produto> data)
        {
            AddRange(data);
        }
        private readonly Dictionary<string, Produto> context = new Dictionary<string, Produto>();        
        public void Add(Produto entry)
        {                        
            context.Add(entry.Prcodi, entry);
        }

        public void AddRange(IEnumerable<Produto> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Delete(Produto entity)
        {
            context.Remove(context.FirstOrDefault(e => e.Value.Equals(entity)).Key);
        }

        public IEnumerable<Produto> GetAll()
        {
            return context.Values.AsEnumerable();
        }

        public Produto GetById(int id)
        {
            return context[id.ToString()];
        }

        public IQueryable<Produto> Query()
        {
            return context.Values.AsQueryable();
        }

        public void SaveChanges()
        {
            //TODO;
        }

        public void Update(Produto entity)
        {
            context[context.FirstOrDefault(e => e.Value == entity).Key] = entity;
        }

        public Produto GetById(string id)
        {
            return context[id];
        }

        public Produto RawSqlQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produto> MultipleFromRawSqlQuery(string query)
        {
            return context.Values;
        }

        public void Command(string query, Produto entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Produto> QueryableByRawQuery(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}
