using Application.Extensions;
using Desktop.MappingProfiles;
using Desktop.ViewModels;
using Desktop.ViewModels.Billings;
using Desktop.ViewModels.Product;
using Desktop.ViewModels.Settings;
using Desktop.ViewModels.Update;
using Desktop.Views.Conta;
using Desktop.Views.Product;
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
        public static void AddDesktopAutoMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfiguration = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DesktopFinancialProfile());
            });
            services.AddSingleton(mapperConfiguration.CreateMapper());
        }
    }
}
