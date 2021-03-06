﻿using DAL.DbContexts;
using DAL.Extensions;
using DAL.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Tests.Lib
{
    public class TestFixture<TStartup> : IDisposable
    {
        public static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {            
            var applicationBasePath = AppContext.BaseDirectory;
            var isDocker = Environment.GetEnvironmentVariable("IS_DOCKER_CONTAINER");
            if(!string.IsNullOrEmpty(isDocker)){                
                return applicationBasePath;
            }
            var directoryInfo = new DirectoryInfo(applicationBasePath);            
            do
            {
                directoryInfo = directoryInfo.Parent;                
                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                var isProjectDirectoryPath = Directory.Exists((projectDirectoryInfo.FullName + "\\src\\Presentation\\Api\\"));
                if (isProjectDirectoryPath) return projectDirectoryInfo.FullName + "\\src\\Presentation\\Api\\";
                
            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }

        protected TestServer Server;
        public IServiceProvider ServiceProvider;

        public TestFixture()
            : this(Path.Combine(""))
        {
            
        }

        public HttpClient Client { get; protected set; }

        public void Dispose()
        {            
            Client.Dispose();
            Server.Dispose();
        }

        protected virtual void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

            var manager = new ApplicationPartManager
            {
                ApplicationParts =
                {
                    new AssemblyPart(startupAssembly)
                },
                FeatureProviders =
                {
                    new ControllerFeatureProvider(),
                    new ViewComponentFeatureProvider()
                }
            };
            
            services.AddSingleton(manager);
            var objectSeedType = typeof(IDataObjectSeed<>);
            var seedObjects = Assembly.GetAssembly(typeof(DAL.DALAssembly))
                                      .GetTypes()
                                      .Where(t => t.GetInterfaces().Any(it => it.IsGenericType && it.Name == objectSeedType.Name))
                                      .ToList();            
            foreach (var seeder in seedObjects)
            {
                var objectInterface = seeder.GetInterface(objectSeedType.Name);
                services.AddSingleton(objectInterface, seeder);
            }
        }

        protected TestFixture(string relativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseConfiguration(configurationBuilder.Build())
                .UseEnvironment("Development")
                .UseStartup(typeof(TStartup));

            // Create instance of test server
            Server = new TestServer(webHostBuilder);

            // Add configuration for client
            Client = Server.CreateClient();
            Client.BaseAddress = Server.BaseAddress;
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            
            ServiceProvider = Server.Services;                  
        }
        public DHsysContext GetRemoteContext()
        {
            var context = ServiceProvider.GetService<DHsysContext>();
            return context;
        }

    }
}
