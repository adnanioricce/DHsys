using Infrastructure.Settings;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUpdater
    {
        void ConfigureUpdater();
        void UpdateSettings(AutoUpdateSettings settings);
        Task Update();
    }
}