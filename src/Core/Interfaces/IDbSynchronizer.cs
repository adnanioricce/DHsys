using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IDbSynchronizer<T>
    {
        IEnumerable<string> GetFilesChanged();
        void AddFileChanged();
        void SyncChanges();
    }
}
