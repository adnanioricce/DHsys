using Desktop.Interfaces;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using Desktop.ViewModels;
using Desktop.Views.Product;
using Core.Interfaces;
using Desktop.Services;
using Desktop.Views.Conta;
using Desktop.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Settings;
using Desktop.ViewModels.Billings;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }        
        public IConfiguration Configuration { get; private set; }
        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context,builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: true);
                })
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(context.Configuration, services);
                })
                .ConfigureLogging(logging =>
                {
                    //TODO:Add loggings
                })
                .Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {            
            await host.StartAsync();                        

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {                        
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(MainWindowViewModel));
            services.AddTransient<CreateBillingViewModel>();
            services.AddTransient<BillingListViewModel>();
            services.AddTransient<CreateProductViewModel>();
            services.AddTransient<ProductListViewModel>();
            services.AddTransient<CreateProductView>();
            services.AddTransient<ProductListView>();
            services.AddTransient<ProductCardControlView>();
            services.AddTransient<BillingListView>();
            services.AddTransient<CreateBillingView>();
            services.AddDbContext<DbContext, MainContext>(opt =>
             {
                 opt.UseSqlite("database.db");
             });
            //services.AddScoped<MainContext>();            
            services.AddScoped(typeof(LegacyContext<>));
            services.AddTransient(typeof(ILegacyRepository<>),typeof(DbfRepository<>));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<CustomNavigationService>(sp =>
            {
                var navigationService = new CustomNavigationService(sp);
                navigationService.Configure(Desktop.Windows.MainWindow, typeof(MainWindow));
                navigationService.Configure(Desktop.Windows.BillingListView, typeof(BillingListView));
                navigationService.Configure(Desktop.Windows.CreateBillingView, typeof(CreateBillingView));
                navigationService.Configure(Desktop.Windows.CreateProductView, typeof(CreateProductView));
                navigationService.Configure(Desktop.Windows.ProductListView, typeof(ProductListView));

                return navigationService;
            });
            ServiceProvider = services.BuildServiceProvider();
            var windowVm = ServiceProvider.GetService<MainWindowViewModel>();
            
        }       
    }
}
