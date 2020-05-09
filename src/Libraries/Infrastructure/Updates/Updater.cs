using Infrastructure.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;
using System.Reflection;
using NetSparkleUpdater;
using NetSparkleUpdater.Enums;
using Infrastructure.Interfaces;
namespace Infrastructure.Updates
{
    public class Updater : IUpdater
    {
        private readonly IAppLogger<Updater> _logger;
        private readonly AutoUpdateSettings _settings;
        private SparkleUpdater _sparkle;
        private Task<UpdateInfo> _updateStatusTask;
        public Updater(IAppLogger<Updater> logger,
            IOptions<AutoUpdateSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }
        public void ConfigureUpdater()
        {            
            var sparkle = new SparkleUpdater(_settings.UpdateFileUrl,                
                securityMode: ToSecurityMode(_settings.SecurityMode),
                dsaPublicKey:_settings.DsaPublicKey,
                Assembly.GetExecutingAssembly().GetName().FullName);
            _sparkle = sparkle;
            if (_settings.ShouldUpdateSilently)
            {
               _sparkle.CheckForUpdatesQuietly();                                
            }
            _sparkle.StartLoop(true);            
        }                
        public async Task Update(bool silently)
        {
            var result = await _sparkle.CheckForUpdatesAtUserRequest();
            if(result.Status == UpdateStatus.UpdateAvailable)
            {
                foreach (var update in result.Updates)
                {
                    _sparkle.InstallUpdate(update);                    
                }
                
            }
        }
        private SecurityMode ToSecurityMode(string securityMode)
        {
            switch (securityMode)
            {
                case "Strict":
                    return SecurityMode.Strict;
                case "Unsafe":
                    return SecurityMode.Unsafe;
                case "UseIfPossible":
                    return SecurityMode.UseIfPossible;
                default:
                    return SecurityMode.Strict;
            }
        }
    }
}
