using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetSparkle;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;
using NetSparkle.Enums;
using System.Reflection;

namespace Infrastructure.Updates
{
    public class Updater
    {
        private readonly IAppLogger<Updater> _logger;
        private readonly AutoUpdateSettings _settings;
        
        public Updater(IAppLogger<Updater> logger,
            IOptions<AutoUpdateSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }
        public void ConfigureUpdater()
        {
            var sparkle = new Sparkle(_settings.AppCastUrl,
                new System.Drawing.Icon(_settings.AppIcon,32,32),
                securityMode:ToSecurityMode(_settings.SecurityMode),
                dsaPublicKey:_settings.DsaPublicKey,
                Assembly.GetExecutingAssembly().GetName().FullName);
            //TODO:
            
        }
        public bool HasUpdate() 
        {
            //TODO:
            return true;
        }
        public async Task Update(bool silently)
        {
            //TODO:            
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
