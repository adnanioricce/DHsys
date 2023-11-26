using Application.Services.Identity;
using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using Infrastructure.Identity;
using Infrastructure.Interfaces.Identity;
using Infrastructure.Services;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.OData.Edm;
using Core.ApplicationModels.Dtos.Catalog;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Api.Handlers;
using Infrastructure.Logging;

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
        static string GetConnectionString(IConfiguration configuration){
            string connectionString = configuration.GetValue<string>("DATABASE_URL");
            var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");            
            if(string.IsNullOrEmpty(connectionString)){
                AppLogger.Information($"DATABASE_URL was null");
                AppLogger.Information($"Using DH_CONNECTION_STRING connection string");
                connectionString = configuration.GetValue<string>("DH_CONNECTION_STRING");
            }
            if(string.IsNullOrEmpty(connectionString)){
                AppLogger.Information($"DH_CONNECTION_STRING was null");
                AppLogger.Information($"Using Default connection string");
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            if (environment.ToLower() == "development" && string.IsNullOrEmpty(connectionString)) {
                AppLogger.Information($"Using DevConnection(appsettings) connection string");
                connectionString = configuration.GetConnectionString("DevConnection");
            }
            if (environment.ToLower() == "production" && string.IsNullOrEmpty(connectionString)) {
                AppLogger.Information($"Using DevConnection(appsettings) connection string");
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            AppLogger.Information($"Using Default(appsettings) connection string");                
            return connectionString;
        } 
        /// <summary>
        /// Add Default data services for the Api application
        /// </summary>
        /// <param name="services">instance of <see cref="IServiceCollection"/> used to registers application services</param>
        public static IServiceCollection AddApiDataStore(this IServiceCollection services)
        {
            Action<IServiceProvider,DbContextOptionsBuilder> setupProdDatabase = (sp,options) => {
                var configuration = sp.GetService<IConfiguration>();
                AppLogger.Information($"Using DefaultConnection connection string");
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString);
            };
            Action<IServiceProvider,DbContextOptionsBuilder> setupDevDatabase = (sp,options) => {
                var opt = sp.GetService<IWritableOptions<ConnectionStrings>>();
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.UseNpgsql(opt.Value.DevConnection);
            };
            services.AddTransient<DHsysContextFactory>();
            var configFunc = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "production"
                ? setupProdDatabase
                : setupDevDatabase;
            services.AddDbContext<DHsysContext, DHsysContext>(configFunc);
            services.AddScoped<DHsysContext, DHsysContext>(provider => {
                AppLogger.Information("Setting up database...");
                var factory = provider.GetService<DHsysContextFactory>();
                var configuration = provider.GetService<IConfiguration>();
                var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");
                
                AppLogger.Information($"Using DefaultConnection connection string");
                
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                AppLogger.Information($"Environment:{environment}");

                if (string.IsNullOrEmpty(connectionString))
                    throw new InvalidOperationException("DefaultConnection config value is not set");

                return factory.CreateContext(connectionString);
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }        
        public static IServiceCollection AddCorsAuthorization(this IServiceCollection services,IWebHostEnvironment environment){
            services.AddAuthorization(options => {
                options.AddPolicy("Default",policy => {
                    policy.RequireAuthenticatedUser();
                });
            });
            return services;
        }
        public static IServiceCollection AddDefaultAuth(this IServiceCollection services,IConfiguration configuration,IWebHostEnvironment environment){
            var jwtTokenConfig = configuration.GetSection("JwtTokenConfig").Get<JwtTokenConfig>();            
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {                
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.AddCorsAuthorization(environment);
            services.AddSingleton<IJwtAuthManager, DefaultJwtManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddTransient<IUserIdentityService, DefaultIdentityService>();
            // services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizeMiddlewareHandler>();
            return services;
        }
        public static IServiceCollection AddAspNetIdentity(this IServiceCollection services,IConfiguration configuration){
            var env = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT")?.ToLower();
            var connStr = configuration.GetConnectionString("Identity");
            AppLogger.Information($"Setting up ASP.NET Identity database on {env} environment");            
            if (string.IsNullOrEmpty(connStr))
            {
                AppLogger.Information($"ASP.NET Identity connection string is null...");
                throw new InvalidOperationException("Identity config value is not set");
            }
            services.AddTransient<IdentityContextFactory>();
            services.AddScoped<IdentityContext>();
            services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connStr));
            services.AddIdentity<AppUser,AppRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            return services;
        }
        public static IServiceCollection ConfigureApi(this IServiceCollection services,IWebHostEnvironment environment)
        {
            IEdmModel GetEdmModel()
            {
                var model = new EdmModel();
                model.AddEntityType(typeof(ProductDto).Namespace,typeof(ProductDto).Name);
                return model;
            }
            services.AddControllersWithViews();
            services.AddMvcCore(options => {
                options.EnableEndpointRouting = true;
                if(environment.EnvironmentName == "Testing"){
                    options.Filters.Add<AllowAnonymousFilter>();
                }
            })
            .AddApiExplorer()
            .AddOData(options => {
                options.AddRouteComponents("odata",GetEdmModel());
            })
            .AddNewtonsoftJson(settings => {
                settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });            
            return services;
        }       
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services){
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    // options.OperationFilter<SwaggerDefaultValues>();
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        BearerFormat="JWT"
                    });
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
                    // options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                    //     new OpenApiSecurityScheme {
                    //         Reference = new OpenApiReference {
                    //             Type = ReferenceType.SecurityScheme,
                    //                 Id = "Bearer"
                    //         }
                    //     },
                    //     new string[] {}
                    // });
                });
            return services;            
        }
    }
}
