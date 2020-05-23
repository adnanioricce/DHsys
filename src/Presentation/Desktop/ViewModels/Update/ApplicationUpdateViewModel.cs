using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Infrastructure.Interfaces;

namespace Desktop.ViewModels.Update
{
    public class ApplicationUpdateViewModel : ViewModelBase
    {
        private readonly IUpdater _updater;
        public RelayCommand UpdateApplicationCommand { get; set; }
        public RelayCommand ConfigureUpdaterCommand { get; set; }
        public ApplicationUpdateViewModel(IUpdater updater)
        {
            _updater = updater;
            //TODO:try to set the updater settings in app startup            
            UpdateApplicationCommand = new RelayCommand(async () => await _updater.Update());
        }        
        
    }
}
