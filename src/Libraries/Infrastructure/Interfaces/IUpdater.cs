using Infrastructure.Settings;
using NetSparkleUpdater.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUpdater
    {
        AutoUpdateSettings Settings { get; }
        void ConfigureUpdater();
        void ConfigureUpdater(IUIFactory uiFactory);
        void CheckForUpdates();
        void UpdateSettings(AutoUpdateSettings settings);
        Task Update();
    }
}