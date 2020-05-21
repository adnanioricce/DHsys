using Desktop.Models.Settings;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;

namespace Desktop.ViewModels.Update
{
    public class ApplicationUpdateViewModel : ViewModelBase
    {
        private readonly IUpdater _updater;
        private readonly IOptionsMonitor<AutoUpdateSettings> _settings;
        private ApplicationUpdateSettingsModel _settingsModel = null;
        public ApplicationUpdateSettingsModel AppUpdateSettingsModel { get { return _settingsModel; }
            set 
            {
                if (_settingsModel == value)
                    Set(ref _settingsModel, value);
            } 
        }
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand UpdateApplicationCommand { get; set; }
        public RelayCommand ConfigureUpdaterCommand { get; set; }
        public RelayCommand<AutoUpdateSettings> EditUpdateSettingsCommand { get; set; }
        public ApplicationUpdateViewModel(IUpdater updater)
        {
            _updater = updater;
            //TODO:try to set the updater settings in app startup            
            UpdateApplicationCommand = new RelayCommand(async () => await _updater.Update());
            EditUpdateSettingsCommand = new RelayCommand<AutoUpdateSettings>(_updater.UpdateSettings);
            LoadCommand = new RelayCommand(Load);            
        }        
        public void Load()
        {
            _settingsModel = new ApplicationUpdateSettingsModel
            {
                DsaPublicKey = _updater.Settings.DsaPublicKey,
                ShouldUpdateSilently = _updater.Settings.ShouldUpdateSilently,
                UpdateFileUrl = _updater.Settings.UpdateFileUrl
            };           
        }
        
    }
}
