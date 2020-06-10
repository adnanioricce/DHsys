using Microsoft.Extensions.DependencyInjection;
using Desktop.ViewModels.Product;
using Desktop.ViewModels.Billings;
using Desktop.ViewModels.Update;
using Desktop.ViewModels.Settings;
using Desktop.ViewModels.Transactions;

namespace Desktop.ViewModels
{
    public class ViewModelLocator
    {        
        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public BillingListViewModel BillingListViewModel => App.ServiceProvider.GetRequiredService<BillingListViewModel>();
        public CreateBillingViewModel CreateBillingViewModel => App.ServiceProvider.GetRequiredService<CreateBillingViewModel>();
        public ProductListViewModel ProductListViewModel => App.ServiceProvider.GetRequiredService<ProductListViewModel>();
        public CreateProductViewModel CreateProductViewModel => App.ServiceProvider.GetRequiredService<CreateProductViewModel>();
        public ApplicationUpdateViewModel ApplicationUpdateViewModel => App.ServiceProvider.GetRequiredService<ApplicationUpdateViewModel>();
        public SettingsViewModel SettingsViewModel => App.ServiceProvider.GetRequiredService<SettingsViewModel>();
        public TransactionListViewModel TransactionListViewModel => App.ServiceProvider.GetRequiredService<TransactionListViewModel>();
    }
}
