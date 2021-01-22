using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;

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
                return new OptionWriter<T>(environment,options, file);
            });
        }
        public static void ConfigureAppDataFolder(this IServiceCollection services,IConfiguration configuration,string myFolder = "DHsys")
        {
            //TODO:Use isolation storage instead
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),myFolder);
            if (!Directory.Exists(folder))
            {
                try{
                    Directory.CreateDirectory(folder);
                }catch(Exception ex)
                {
                    throw;
                }
            }
            //Create appsettings.json file on AppData Folder
            string appsettingsPath = Path.Combine(folder,"appsettings.json");
            if (!File.Exists(appsettingsPath))
            {
                if (File.Exists("appsettings.json"))
                {
                    var appsettingsContent = File.ReadAllLines("appsettings.json");                    
                    var lines = string.Join("\n", appsettingsContent);
                    File.WriteAllText(appsettingsPath, lines);
                    return;
                }
                File.Create(appsettingsPath);
            }
            //create updates folder on AppData Folder
            string updateFilesFolder = Path.Combine(folder,"Updates");
            if (!File.Exists(updateFilesFolder))
            {
                Directory.CreateDirectory(updateFilesFolder);
            }
        }        
    }
}
