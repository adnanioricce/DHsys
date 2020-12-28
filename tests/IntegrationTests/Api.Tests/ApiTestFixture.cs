using Application.Extensions;
using Core.Extensions;
using Core.Validations;
using DAL.DbContexts;
using DAL.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Tests.Lib;

namespace Api
{
    public class ApiTestFixture : IDisposable
    {
        protected TestServer Server;
        public IServiceProvider ServiceProvider;
        public HttpClient Client { get; protected set; }
        public ODataClient ODataClient { get; protected set; }
        public ApiTestFixture() : this(Path.Combine(""))
        {

        }
        public static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        {
            var projectName = startupAssembly.GetName().Name;

            var applicationBasePath = AppContext.BaseDirectory;
            var isDocker = Environment.GetEnvironmentVariable("IS_DOCKER_CONTAINER");
            if (!string.IsNullOrEmpty(isDocker))
            {
                return applicationBasePath;
            }
            var directoryInfo = new DirectoryInfo(applicationBasePath);
            if(string.Equals(directoryInfo.Name.ToLower(),"dhsys")){
                return directoryInfo.FullName + "/src/Presentation/Api";
            }
            do
            {
                directoryInfo = directoryInfo.Parent;
                var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
                var isProjectDirectoryPath = Directory.Exists((projectDirectoryInfo.FullName + "/src/Presentation/Api/"));
                if (isProjectDirectoryPath) return projectDirectoryInfo.FullName + "/src/Presentation/Api/";

            }
            while (directoryInfo.Parent != null);

            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }
        protected ApiTestFixture(string relativeTargetProjectParentDir)
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseConfiguration(configurationBuilder.Build())
                .UseEnvironment("Development")
                .UseStartup(typeof(Startup));

            // Create instance of test server
            Server = new TestServer(webHostBuilder);

            // Add configuration for client
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
            
            Client = Server.CreateClient();
            Client.BaseAddress = Server.BaseAddress;
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ODataClient = new ODataClient($"{Server.BaseAddress}api/");            
            ServiceProvider = Server.Services;
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }

        protected void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;

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
            var validators = Assembly.GetAssembly(typeof(Core.Core))
                                     .GetTypesWithBaseType(typeof(BaseValidator<>))
                                     .ToList();
            foreach (var validator in validators)
            {
                services.AddTransient(validator.BaseType, validator);
            }
            services.AddAutoMapperConfiguration();
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            }).AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();                                
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });            
            
        }
        public DHsysContext GetContext()
        {
            var context = ServiceProvider.GetService<DHsysContext>();
            return context;
        }
    }
}
