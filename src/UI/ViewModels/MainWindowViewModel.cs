using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ViewModelLocator _locator;
        public RelayCommand MoveToAddContaViewCommand { get; set; }
        public RelayCommand MoveToContaListViewCommand { get; set; }
        public object DataContext { get; set; }
        public MainWindowViewModel(ViewModelLocator locator)
        {
            _locator = locator;
        }
        public void MoveToAddContaView()
        {            
            DataContext = _locator.AddContaViewModel;
        }
        public void MoveToContaListView()
        {            
            DataContext = _locator.ContaListViewModel;
        }                
    }
}
