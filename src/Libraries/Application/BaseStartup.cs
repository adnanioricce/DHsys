using Application.Extensions;
using Core.Interfaces;
using DAL;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Application
{
    public class BaseStartup
    {
        public IConfiguration Configuration { get; }
        public BaseStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }       
        public virtual void ConfigureServices(IServiceCollection services)
        {            
            services.ConfigureAppDataFolder();
            //TODO:Remove AddApplicationUpdater call, just the desktop project needs it
            services.AddApplicationUpdater();
            services.AddApplicationServices();            
            services.ConfigureApplicationOptions(Configuration);
            services.AddAutoMapperConfiguration();
        }

    }
}
