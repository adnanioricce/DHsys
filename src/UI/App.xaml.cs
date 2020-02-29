using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;
using UI.Services;
using UI.ViewModels;
using UI.Views;
using UI.Views.Product;

namespace UI
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
        protected override void OnStartup(StartupEventArgs e)
        {            
            host.Start();
            //var navigationService = ServiceProvider.GetRequiredService<CustomNavigationService>();

            //await navigationService.ShowAsync(UI.Windows.MainWindow);
            //var mainWindow = host.Services.GetRequiredService<MainWindow>();
            //mainWindow.Show();

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
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(MainWindowViewModel));
            services.AddTransient(typeof(ContaListViewModel));
            services.AddTransient(typeof(AddProductView));
            services.AddTransient(typeof(ProductListView));
            services.AddTransient(typeof(ProductView));
            services.AddScoped<MainContext>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            ServiceProvider = services.BuildServiceProvider();
        }       
    }
}
