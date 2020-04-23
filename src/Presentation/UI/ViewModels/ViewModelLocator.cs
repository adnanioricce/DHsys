using Microsoft.Extensions.DependencyInjection;
using UI.ViewModels.Product;

namespace UI.ViewModels
{
    public class ViewModelLocator
    {        
        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public BillingListViewModel BillingListViewModel => App.ServiceProvider.GetRequiredService<BillingListViewModel>();
        public CreateBillingViewModel CreateBillingViewModel => App.ServiceProvider.GetRequiredService<CreateBillingViewModel>();
        public ProductListViewModel ProductListViewModel => App.ServiceProvider.GetRequiredService<ProductListViewModel>();
        public CreateProductViewModel CreateProductViewModel => App.ServiceProvider.GetRequiredService<CreateProductViewModel>();
    }
}
