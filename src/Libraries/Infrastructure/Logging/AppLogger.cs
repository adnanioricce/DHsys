using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Infrastructure.Logging
{
    public static class AppLogger 
    {
        public static readonly Serilog.ILogger Log = Serilog.Log.Logger;        
        public static void Information(string template,params object[] @params){
            Log.Information(template,@params);
        }
        public static void Information(string message){
            Log.Information(message);
        }
        public static void Debug(string template,params object[] @params){
            Log.Debug(template,@params);
        }
        public static void Debug(string message){
            Log.Debug(message);
        }
        public static void Error(string template,params object[] @params){
            Log.Error(template,@params);
        }
        public static void Error(string message){
            Log.Error(message);
        }
        public static void Warning(string template,params object[] @params){
            Log.Warning(template,@params);
        }        
        public static void Warning(string message){
            Log.Warning(message);
        }
    }    
}
