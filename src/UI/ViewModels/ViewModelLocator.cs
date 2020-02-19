using Microsoft.Extensions.DependencyInjection;

namespace UI.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();
        public ContaViewModel ContaViewModel => App.ServiceProvider.GetRequiredService<ContaViewModel>();
    }
}
