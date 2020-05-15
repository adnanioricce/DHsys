using Infrastructure.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;
using System.Reflection;
using NetSparkleUpdater;
using NetSparkleUpdater.Enums;
using NetSparkleUpdater.Interfaces;

namespace Infrastructure.Updates
{
    public class Updater : IUpdater
    {
        private readonly IAppLogger<Updater> _logger;
        private readonly AutoUpdateSettings _settings;
        private readonly IWritableOptions<AutoUpdateSettings> _settingsWriter;
        private SparkleUpdater _sparkle;        
        public Updater(IAppLogger<Updater> logger,
            IWritableOptions<AutoUpdateSettings> settingsWriter,
            IOptions<AutoUpdateSettings> settings)
        {
            _logger = logger;
            _settingsWriter = settingsWriter;
            _settings = settings.Value;
        }
        public void ConfigureUpdater()
        {            
            var sparkle = new SparkleUpdater(_settings.UpdateFileUrl,                
                securityMode: ToSecurityMode(_settings.SecurityMode),
                dsaPublicKey:_settings.DsaPublicKey,
                Assembly.GetExecutingAssembly().GetName().FullName);
            //sparkle.UIFactory = NetSparkleUpdater.
            _sparkle = sparkle;
            if (_settings.ShouldUpdateSilently)
            {
               _sparkle.CheckForUpdatesQuietly();                                
            }
            _sparkle.StartLoop(true);            
        }
        public async Task Update()
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

        public void UpdateSettings(AutoUpdateSettings settings)
        {
            //TODO:Validation to avoid user to break update process
            _settingsWriter.Update((options) => options = settings);
        }

        private SecurityMode ToSecurityMode(string securityMode)
        {
            return securityMode switch
            {
                "Strict" => SecurityMode.Strict,
                "Unsafe" => SecurityMode.Unsafe,
                "UseIfPossible" => SecurityMode.UseIfPossible,
                _ => SecurityMode.Strict,
            };
        }
    }
}
