namespace Core.Interfaces
{
    public interface IDbSynchronizer<T>
    {
        void SyncChanges();
    }
}
