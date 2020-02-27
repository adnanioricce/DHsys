using Core.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace UI.Tests
{
    public class FakeRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly Dictionary<int, T> context = new Dictionary<int, T>();
        private int counter = 1;
        public void Add(T entry)
        {
            if (entry.Id <= 0 || entry.Id == null)
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
            return context.Values.ToList();
        }

        public T GetById(int id)
        {
            return context.FirstOrDefault(e => e.Key == id).Value;
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
    }
}
