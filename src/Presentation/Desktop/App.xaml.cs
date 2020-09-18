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
using System.Linq;
using DAL.DbContexts;
using DAL.Extensions;
using Infrastructure.Interfaces;
using DAL.Windows;
using DAL.Windows.Repositories;
using Infrastructure.Logging;
using Core.Validations;

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
            ConfigureLoggingExtension.ConfigureDefaultSerilogLogger();
            host = Host.CreateDefaultBuilder()                
                .ConfigureAppConfiguration((context,builder) =>
                {                    
                    builder.AddJsonFile("appsettings.json", optional: true);
                })
                .ConfigureServices((context, services) =>
                {                    
                    ConfigureServices(context.Configuration, services);
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
            services.Configure<AutoUpdateSettings>(configuration.GetSection($"{nameof(AppSettings)}:{nameof(AutoUpdateSettings)}"));
            services.ConfigureWritableOptionsModel();
            services.ConfigureAppDataFolder();            
            services.AddApplicationUpdater();            
            services.AddApplicationServices();            
            services.AddAutoMapperConfiguration();
            services.AddViews();
            services.AddViewModels();
            services.AddDataStore(configuration,opt => opt.UseSqlite(configuration.GetValue<string>($"{nameof(AppSettings)}:{nameof(DatabaseSettings)}:{nameof(ConnectionStrings)}:LocalConnection")));
            services.AddTransient(typeof(ILegacyRepository<>),typeof(ProdutoRepository<>));
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            services.AddScoped<CustomNavigationService>(ConfigureNavigationService);
            services.AddSingleton<IFileSystemService, IOService>();
            services.AddTransient<DbContextResolver>(provider => key => {
                string option = key.ToLower();
                var services = provider.GetServices(typeof(BaseContext));
                return option switch
                {
                    "remote" => (BaseContext)services.FirstOrDefault(d => (d is RemoteContext)),
                    "local" => (BaseContext)services.FirstOrDefault(d => (d is LocalContext)),
                    _ => (BaseContext)services.FirstOrDefault(d => (d is LocalContext))
                };
            });
            var validators = Assembly.GetAssembly(typeof(Core.Core))
                                     .GetTypes()
                                     .Where(t => t.IsClass && t.BaseType.Name.StartsWith("BaseValidator"))
                                     .ToList();
            foreach (var validator in validators)
            {
                services.AddTransient(validator.BaseType, validator);
            }
            ServiceProvider = services.BuildServiceProvider();
            var dbResolver = ServiceProvider.GetRequiredService<DbContextResolver>();
            var dbcontext = dbResolver("local");
            dbcontext.ApplyUpgrades();
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
