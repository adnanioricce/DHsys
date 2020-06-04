using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using Desktop.Views.Product;
using Core.Interfaces;
using Desktop.Services;
using Desktop.Views.Conta;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Settings;
using Application.Extensions;
using Desktop.Extensions;
using System.Reflection;
using System.IO;
using DAL.DbContexts;
using DAL.Extensions;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
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

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services){
            //Creating assembly reference file
            var assembly = Assembly.GetExecutingAssembly();
            string assemblyContent = assembly.FullName;
            string assemblyName = assembly.GetName().Name;
            File.WriteAllText(assemblyName, assemblyContent);
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));
            services.Configure<DatabaseSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}"));
            services.Configure<LegacyDatabaseSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}:{nameof(LegacyDatabaseSettings)}"));
            services.Configure<AutoUpdateSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(AutoUpdateSettings)}"));
            services.ConfigureWritableOptionsModel();
            services.ConfigureAppDataFolder();            
            services.AddApplicationUpdater();            
            services.AddApplicationServices();            
            services.AddCustomMappers();
            services.AddViews();
            services.AddViewModels();
            services.AddDataStore(configuration);
            services.AddTransient(typeof(ILegacyRepository<>),typeof(DbfRepository<>));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<CustomNavigationService>(ConfigureNavigationService);            
            ServiceProvider = services.BuildServiceProvider();
            var dbResolver = ServiceProvider.GetRequiredService<DbContextResolver>();
            ServiceProvider.TryCreateDatabase(dbResolver("local"));            
        }                        
        private CustomNavigationService ConfigureNavigationService(IServiceProvider provider)
        {
            var navigationService = new CustomNavigationService(provider);
            navigationService.Configure(Desktop.Windows.MainWindow, typeof(MainWindow));
            navigationService.Configure(Desktop.Windows.BillingListView, typeof(BillingListView));
            navigationService.Configure(Desktop.Windows.CreateBillingView, typeof(CreateBillingView));
            navigationService.Configure(Desktop.Windows.CreateProductView, typeof(CreateProductView));
            navigationService.Configure(Desktop.Windows.ProductListView, typeof(ProductListView));
            return navigationService;
        }
    }
}
