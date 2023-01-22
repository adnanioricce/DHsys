using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infrastructure.Logging
{
    public static class ConfigureLoggingExtension
    {
        /// <summary>
        /// Configures a default instance of <see cref="Logger"/>. 
        /// <para>Minimum Log Level to file is debug, console log information level events </para>        
        /// </summary>
        /// <param name="logDir">the dir where write log files</param>
        /// <returns>a instance of <see cref="Logger"/></returns>
        public static Serilog.ILogger ConfigureDefaultSerilogLogger(string logDir = "")
        {
            if (string.IsNullOrEmpty(logDir))
            {
                logDir = $"{AppDomain.CurrentDomain.BaseDirectory}/logs";
            }
            try
            {
                if(!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }   
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($" --> Failed to create logs directory when creating logger. \n exception:{ex.ToString()}");
            }            
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                        .WriteTo.File($"{logDir}/log.txt", outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")                                    
                        .CreateLogger();
            AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();            
            return Log.Logger;            
        }        
    }
}
