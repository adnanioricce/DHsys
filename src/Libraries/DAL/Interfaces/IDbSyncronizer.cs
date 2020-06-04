using Core.Models;
using DAL.DbContexts;
using System.Data;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDbSyncronizer
    {        
        Task<BaseResult<object>> SyncLocalDbWithRemoteDbAsync(LocalContext localContext,RemoteContext remoteContext);
        Task<BaseResult<object>> SyncLocalDbWithRemoteDbAsync();
    }
}
