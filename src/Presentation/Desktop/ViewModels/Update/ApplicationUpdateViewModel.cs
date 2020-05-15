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
            //TODO:this is not a good idea,try to set the updater settings in app startup
            ConfigureUpdaterCommand = new RelayCommand(_updater.ConfigureUpdater);
            UpdateApplicationCommand = new RelayCommand(async () => await _updater.Update());
        }        
        
    }
}
