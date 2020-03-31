using System.Collections.Generic;
using System.Linq;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;

namespace Tests.Lib.Data
{
    public class FakeLegacyRepository<T> : ILegacyRepository<T> where T : Produto
    {
        public FakeLegacyRepository()
        {
            
        }
        public FakeLegacyRepository(IEnumerable<T> data)
        {
            AddRange(data);
        }
        private readonly Dictionary<string, T> context = new Dictionary<string, T>();        
        public void Add(T entry)
        {                        
            context.Add(entry.Prcodi, entry);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Delete(T entity)
        {
            context.Remove(context.FirstOrDefault(e => e.Value.Equals(entity)).Key);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Values.AsEnumerable();
        }

        public T GetById(int id)
        {
            return context[id.ToString()];
        }

        public IQueryable<T> Query()
        {
            return context.Values.AsQueryable();
        }

        public void SaveChanges()
        {
            //TODO;
        }

        public void Update(T entity)
        {
            context[context.FirstOrDefault(e => e.Value == entity).Key] = entity;
        }

        public T GetById(string id)
        {
            return context[id];
        }

        public T RawSqlQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> MultipleFromRawSqlQuery(string query)
        {
            throw new System.NotImplementedException();
        }

        public void Command(string query, T entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> QueryableByRawQuery(string query)
        {
            throw new System.NotImplementedException();
        }
    }
}
