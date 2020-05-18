using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Settings
{
    public class SettingsViewModel
    {
        public object CurrentSectionViewModel { get; set; }
        public RelayCommand<object> ChangeSectionViewModelCommand { get; set; }
        public SettingsViewModel()
        {
            ChangeSectionViewModelCommand = new RelayCommand<object>((viewModel) => CurrentSectionViewModel = viewModel);
        }        

    }
}
