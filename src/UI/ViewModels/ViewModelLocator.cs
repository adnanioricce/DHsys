using Microsoft.Extensions.DependencyInjection;

namespace UI.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public ContaListViewModel ContaViewModel => App.ServiceProvider.GetRequiredService<ContaListViewModel>();
    }
}
