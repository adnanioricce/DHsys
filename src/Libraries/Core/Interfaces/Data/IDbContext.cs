using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    //How??
    public interface IDbContext
    {
        void Add(object entity);
        void Add<T>(object entity);
        void AddRange(params object[] entities);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
