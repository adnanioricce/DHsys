using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUpdater
    {
        void ConfigureUpdater();
        Task Update(bool silently);
    }
}