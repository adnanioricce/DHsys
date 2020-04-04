using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;

namespace Tests.Lib.Data
{
    public class FakeRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Dictionary<int, T> context = new Dictionary<int, T>();
        private int counter = 1;        
        public FakeRepository()
        {
            
        }
        public FakeRepository(IEnumerable<T> data)
        {
            AddRange(data);
        }
        
        
        public void Add(T entry)
        {
            if (entry.Id <= 0)
            {
                entry.Id = counter;
                context.Add(entry.Id, entry);
                ++counter;
            }
            entry.Id = counter;
            context.Add(entry.Id, entry);
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

        public T GetBy(int id)
        {
            return context[id];
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
            context[entity.Id] = entity;
        }

        public T GetBy(string id)
        {
            return context.Values.FirstOrDefault(i => i.UniqueCode == id);
        }

        public IQueryable<T> Query(string query)
        {
            return context.Values.AsQueryable(); 
        }
    }
}
