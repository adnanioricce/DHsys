using System;
using System.IO;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ConfigureLoggingExtension.ConfigureDefaultSerilogLogger("./logs");            
            try
            {
                var hostBuilder = CreateHostBuilder(args);
                var host = hostBuilder.Build();
                host.Run();
                return 0;
            }catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }            
        }        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureAppConfiguration((hostingContext, config) => {
                    var configuration = new ConfigurationBuilder()
                            .AddEnvironmentVariables("ASPNETCORE_")
                            .AddJsonFile("appsettings.json",optional: true,reloadOnChange:true)
                            .AddJsonFile("appsettings.{Environment}.json",optional:true,reloadOnChange:true)
                            .Build();
                    config.AddConfiguration(configuration);
                })
                .ConfigureWebHostDefaults(webBuilder => {                    
                    webBuilder.UseStartup<Startup>();
                });      
    }
}
