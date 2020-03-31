using Microsoft.Extensions.DependencyInjection;

namespace UI.ViewModels
{
    public class ViewModelLocator
    {        
        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public ContaListViewModel ContaListViewModel => App.ServiceProvider.GetRequiredService<ContaListViewModel>();
        public AddContaViewModel AddContaViewModel => App.ServiceProvider.GetRequiredService<AddContaViewModel>();
    }
}
