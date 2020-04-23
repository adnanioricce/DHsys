﻿using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //? I think is valid to remember that you still have to configure the option model before calling this
        public static void ConfigureWritable<T>(this IServiceCollection services,
            string sectionKey,            
            string file = "appsettings.json") where T : class, new()
        {            
            services.AddTransient<OptionWriter<T>>(provider =>
            {
                var environment = provider.GetService<IHostEnvironment>();
                var options = provider.GetService<IOptionsMonitor<T>>();
                return new OptionWriter<T>(environment, options, sectionKey, file);
            });
        }
    }
}
