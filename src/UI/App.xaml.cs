﻿using Core.Interfaces;
using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.ViewModels;
using UI.Views.Product;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();            
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
        
        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(ContaViewModel));
            services.AddTransient(typeof(AddProductView));
            services.AddTransient(typeof(ProductListView));
            services.AddTransient(typeof(ProductView));
            services.AddScoped<MainContext>();
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
        }
        public App()
        {
            //using (var context = new MainContext()) 
            //{
            //    context.Database.EnsureCreated();
            //} 
        }
    }
}
