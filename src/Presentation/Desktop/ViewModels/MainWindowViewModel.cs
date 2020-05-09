using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Desktop.Services;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Options;
using Infrastructure.Settings;

namespace Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentDataContext = null;        
        public RelayCommand<object> MoveToViewModelCommand { get; set; }
        public RelayCommand<bool> CheckForUpdatesCommand { get; set; }
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
            MoveToViewModelCommand = new RelayCommand<object>(MoveToView);
            CheckForUpdatesCommand = new RelayCommand<bool>(async (isSilently) => await updater.Update(settings.Value.ShouldUpdateSilently));
        }
        public void MoveToView(object parameter)
        {            
            CurrentDataContext = parameter;            
        }        
    }
}
