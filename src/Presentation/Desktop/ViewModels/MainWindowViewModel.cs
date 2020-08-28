using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Desktop.Services;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;
using NetSparkleUpdater.Interfaces;

namespace Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentDataContext = null;        
        public RelayCommand<object> MoveToViewModelCommand { get; set; }
        public RelayCommand CheckForUpdatesCommand { get; set; }
        private readonly IUpdater _updater;
        public object CurrentDataContext
        {
            get { return _currentDataContext; }
            set
            {                
                Set(ref _currentDataContext, value);
            }
        }
        public MainWindowViewModel(IUpdater updater,IOptions<AutoUpdateSettings> settings)
        {
            _updater = updater;
            MoveToViewModelCommand = new RelayCommand<object>(MoveToView);
            CheckForUpdatesCommand = new RelayCommand(ConfigureUpdater);
        }
        public void MoveToView(object parameter)
        {            
            CurrentDataContext = parameter;            
        }        
        public void ConfigureUpdater()
        {
            _updater.ConfigureUpdater(new NetSparkleUpdater.UI.WPF.UIFactory());
        }
    }
}
