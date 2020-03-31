using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels.Product;

namespace UI.ViewModels
{
    public class ViewModelLocator
    {        
        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public ContaListViewModel ContaListViewModel => App.ServiceProvider.GetRequiredService<ContaListViewModel>();
        public AddContaViewModel AddContaViewModel => App.ServiceProvider.GetRequiredService<AddContaViewModel>();
        public ProductListViewModel ProductListViewModel => App.ServiceProvider.GetRequiredService<ProductListViewModel>();
        public ProductViewModel ProductViewModel => App.ServiceProvider.GetRequiredService<ProductViewModel>();
    }
}
