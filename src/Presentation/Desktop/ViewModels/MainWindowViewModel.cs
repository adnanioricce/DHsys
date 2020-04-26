using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Desktop.Services;

namespace Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentDataContext = null;
        private readonly CustomNavigationService _navigationService;
        public RelayCommand<object> MoveToViewModelCommand { get; set; }                
        public object CurrentDataContext
        {
            get { return _currentDataContext; }
            set
            {                
                Set(ref _currentDataContext, value);
            }
        }
        public MainWindowViewModel(CustomNavigationService navigationService)
        {
            _navigationService = navigationService;
            MoveToViewModelCommand = new RelayCommand<object>(MoveToView);             
        }
        public void MoveToView(object parameter)
        {            
            CurrentDataContext = parameter;            
        }        
    }
}
