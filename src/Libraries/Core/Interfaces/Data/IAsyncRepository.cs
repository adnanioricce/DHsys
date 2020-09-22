using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IAsyncRepository<T> 
    {
        Task<T> GetByAsync(object id);
        Task<T> GetByAsync(int id);
        Task<T> GetByAsync(string uniqueCode);
        Task<IEnumerable<T>> GetAllAsync();
        IAsyncEnumerable<T> GetAsyncEnumerable();
        Task<int> SaveChangesAsync();
    }
}
