using Core.Models.Resources.Requests;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDbSynchronizer
    {
        string GenerateSyncScript(SyncDatabaseRequest request);

        void SyncDbfChanges();
    }
}
