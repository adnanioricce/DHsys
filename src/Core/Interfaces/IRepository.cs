using System.Collections.Generic;
using System.Linq;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetBy(int id);
        T GetBy(string id);
        void Add(T entry);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
        IQueryable<T> Query(string query);
        void SaveChanges();
    }
}
