using Application.Extensions;
using Desktop.MappingProfiles;
using Desktop.ViewModels;
using Desktop.ViewModels.Billings;
using Desktop.ViewModels.Product;
using Desktop.ViewModels.Settings;
using Desktop.ViewModels.Update;
using Desktop.Views.Conta;
using Desktop.Views.Product;
using GalaSoft.MvvmLight;
using Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

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
            var viewModels = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => t.BaseType == typeof(ViewModelBase))
                    .ToList();
            viewModels.ForEach(viewModel => services.AddTransient(viewModel));
        }
        public static void ConfigureWritableOptionsModel(this IServiceCollection services)
        {
            services.ConfigureWritable<AutoUpdateSettings>();                        
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
