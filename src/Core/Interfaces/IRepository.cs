using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entry);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
        void SaveChanges();
    }
}
