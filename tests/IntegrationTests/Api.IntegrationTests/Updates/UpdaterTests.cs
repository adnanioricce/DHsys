using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Infrastructure.Updates;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Updates
{
    public class UpdaterTests
    {
        private readonly IAppLogger<Updater> _logger;
        private readonly IWritableOptions<AutoUpdateSettings> _writableSettings;
        private readonly IOptions<AutoUpdateSettings> _settings;
        public UpdaterTests(IAppLogger<Updater> logger,
            IWritableOptions<AutoUpdateSettings> writableSettings,
            IOptions<AutoUpdateSettings> settings)
        {
            _logger = logger;
            _writableSettings = writableSettings;
            _settings = settings;
        }
        //TODO:unit test for methods:ConfigureUpdater and Update 

        [Fact]
        public void Given_Settings_Object_With_Different_State_From_Saved_When_Passes_Setting_To_Updater_Service_Then_Save_Changes_On_Config_Object()
        {
            // Given
            var updater = new Updater(_logger, _writableSettings, _settings);
            AutoUpdateSettings settings = _settings.Value;
            settings.ShouldUpdateSilently = false;

            // When
            updater.UpdateSettings(settings);
            var updatedSettings = _writableSettings.Value;
            // Then
            Assert.False(updatedSettings.ShouldUpdateSilently);
        }        
    }
}
