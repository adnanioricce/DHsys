using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        private object _currentDataContext = null;
        public object CurrentSectionViewModel
    {
            get { return _currentDataContext; }
            set
            {                
                Set(ref _currentDataContext, value);
            }
        }
        public RelayCommand<object> ChangeSectionViewModelCommand { get; set; }
        public SettingsViewModel()
        {
            ChangeSectionViewModelCommand = new RelayCommand<object>((viewModel) => CurrentSectionViewModel = viewModel);
        }        

    }
}
