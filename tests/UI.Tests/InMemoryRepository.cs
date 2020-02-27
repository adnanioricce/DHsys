using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace UI.Tests
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly FakeContext _context;
        public InMemoryRepository(FakeContext context)
        {
            _context = context;
        }
        public void Add(T entry)
        {
            throw new System.NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> Query()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
