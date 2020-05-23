namespace Core.Interfaces
{
    public interface IOleDbContext
    {
        void OnConfiguring();
        void ModelCreating();
    }   
}