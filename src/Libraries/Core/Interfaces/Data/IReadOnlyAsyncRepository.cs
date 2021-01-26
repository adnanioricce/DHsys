using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Data
{
    public interface IReadOnlyAsyncRepository<T>
    {
        Task<T> GetByAsync(int id);
        Task<T> QuerySingleAsync(string query);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> QueryListAsync(string query);        
    }
}
