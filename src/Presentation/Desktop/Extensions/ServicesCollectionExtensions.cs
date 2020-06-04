using Application.Extensions;
using Application.Services;
using Application.Services.Catalog;
using Application.Services.Sync;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Core.Mappers;
using Desktop.ViewModels;
using Desktop.ViewModels.Billings;
using Desktop.ViewModels.Product;
using Desktop.ViewModels.Settings;
using Desktop.ViewModels.Update;
using Desktop.Views.Conta;
using Desktop.Views.Product;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddViews(this IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindow));
            services.AddTransient<CreateProductView>();
            services.AddTransient<ProductListView>();
            services.AddTransient<ProductCardControlView>();
            services.AddTransient<BillingListView>();
            services.AddTransient<CreateBillingView>();
        }
        public static void AddViewModels(this IServiceCollection services)
        {
            services.AddTransient(typeof(MainWindowViewModel));
            services.AddTransient<CreateBillingViewModel>();
            services.AddTransient<BillingListViewModel>();
            services.AddTransient<CreateProductViewModel>();
            services.AddTransient<ProductListViewModel>();
            services.AddTransient<ApplicationUpdateViewModel>();
            services.AddTransient<SettingsViewModel>();
        }
        public static void ConfigureWritableOptionsModel(this IServiceCollection services)
        {
            services.ConfigureWritable<AutoUpdateSettings>();            
            services.ConfigureWritable<LegacyDatabaseSettings>();
            services.ConfigureWritable<ConnectionStrings>();
            services.ConfigureWritable<DatabaseSettings>();
            services.ConfigureWritable<AppSettings>();
        }
    }
}
