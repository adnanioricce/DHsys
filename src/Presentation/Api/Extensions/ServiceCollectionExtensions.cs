using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using DAL.Identity;
using IdentityServer4.Services;
using Infrastructure.Settings;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;
namespace Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainValidators(this IServiceCollection services)
        {
            var validators = Assembly.GetAssembly(typeof(Core.Core)).GetTypes()
                                                                    .Where(t => !string.IsNullOrEmpty(t.Namespace))
                                                                    .Where(t => t.Namespace.StartsWith("Core.Validations"))
                                                                    .Where(t => !t.Name.StartsWith("BaseValidator"));
            foreach (var validator in validators) {
                services.AddTransient(validator.BaseType,validator);
            }
            return services;
        }
        /// <summary>
        /// Add OData services and configures it's input and output media formats
        /// </summary>
        /// <param name="services"></param>
        /// <returns>a instance of <see cref="IServiceCollection"/> with the added services and options for OData support</returns>
        public static IServiceCollection AddOdataSupport(this IServiceCollection services)
        {
            services.AddOData()
                .EnableApiVersioning();
            services.AddMvcCore(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters
                                                       .OfType<ODataOutputFormatter>()
                                                       .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters
                                                      .OfType<ODataInputFormatter>()
                                                      .Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
            return services;
        }
        /// <summary>
        /// Add Default data services for the Api application
        /// </summary>
        /// <param name="services">instance of <see cref="IServiceCollection"/> used to registers application services</param>
        public static IServiceCollection AddApiDataStore(this IServiceCollection services)
        {
            services.AddTransient<DHsysContextFactory>();
            services.AddDbContext<DHsysContext, DHsysContext>((sp,options) => {
                var configuration = sp.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");                
                if (GlobalConfiguration.IsDockerContainer) {
                    string connectionString = GlobalConfiguration.DhConnectionString;
                    options.UseNpgsql(connectionString);
                    return;
                }
                var opt = sp.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development")
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();                    
                    options.UseNpgsql(opt.Value.DevConnection);
                    return;
                }
                
                options.UseNpgsql(opt.Value.DefaultConnection);
             });
            services.AddScoped<DHsysContext, DHsysContext>(provider => {
                var factory = provider.GetService<DHsysContextFactory>();
                var configuration = provider.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("environment");
                if (GlobalConfiguration.IsDockerContainer) {                    
                    if(!String.IsNullOrEmpty(configuration.GetValue<string>("DATABASE_URL"))){
                        return factory.CreateContext(configuration.GetValue<string>("DATABASE_URL"));    
                    }
                    string connectionString = configuration.GetValue<string>("DH_CONNECTION_STRING");                    
                    return factory.CreateContext(connectionString);
                }
                var options = provider.GetService<IWritableOptions<ConnectionStrings>>();
                if (environment == "Development") {
                    return factory.CreateContext(options.Value.DevConnection,isDevelopment:true);
                }                
                
                return factory.CreateContext(options.Value.DefaultConnection);                
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
        ///<summary>
        /// Add the necessary pipelines to handle authentication.
        ///</summary>
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services,IWebHostEnvironment environment)
        {
            var migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;                                
            var builder = services.AddIdentityServer(options => {
                                    options.Events.RaiseErrorEvents = true;
                                    options.Events.RaiseFailureEvents = true;
                                    options.Events.RaiseInformationEvents = true;
                                    options.Events.RaiseSuccessEvents = true;
                                })
                                .AddInMemoryIdentityResources(Config.IdentityResources)
                                .AddInMemoryApiScopes(Config.ApiScopes)
                                .AddInMemoryClients(Config.Clients)                                                                        
                                .AddAspNetIdentity<AppUser>();
            if(environment.EnvironmentName == "Development"){
                builder.AddDeveloperSigningCredential();
            }
            services.AddAuthentication()
                    .AddLocalApi()
                    .AddIdentityServerJwt();
            services.AddAuthorization(options => {
                if(environment.EnvironmentName == "Development"){
                    options.AddPolicy("Default",policy => {
                        policy.RequireAuthenticatedUser();                            
                        policy.RequireAssertion(context => {                                
                            return context.User.HasClaim(c => (c.Type == "scope" && c.Value == "swagger") || (c.Type == "scope" && c.Value == "dhsysapi"));
                        });
                    });
                }else {
                    options.AddPolicy("Default",policy => {
                        policy.RequireAuthenticatedUser();
                        policy.RequireClaim("scope","admin");
                        policy.RequireClaim("role","admin");
                    });
                }

            });
            services.AddSingleton<ICorsPolicyService>((container) => {
                var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
                return new DefaultCorsPolicyService(logger) {
                    AllowedOrigins = { "http://localhost:9527"}
                };
            });
            return services;
        }
        public static IServiceCollection AddAspNetIdentityIdentity(this IServiceCollection services,IConfiguration configuration){
            string identityConnStr = configuration.GetSection("Identity:Db")["Identity"];
            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(identityConnStr));
            services.AddIdentity<AppUser,IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
        public static IServiceCollection ConfigureApi(this IServiceCollection services,IWebHostEnvironment environment)
        {
            services.AddControllersWithViews();
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
                if(environment.EnvironmentName == "Testing"){
                    options.Filters.Add<AllowAnonymousFilter>();
                }
            }).AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddApiVersioning(options => options.ReportApiVersions = true);            
            return services;
        }
        public static IServiceCollection AddOdataConfiguration(this IServiceCollection services){
            services.AddOdataSupport();
            services.AddODataApiExplorer();
            return services;
        }
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services){
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();
            });
            return services;            
        }
    }
}
