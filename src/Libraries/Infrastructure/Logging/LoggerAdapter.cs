using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Infrastructure.Logging
{
    public static class AppLogger 
    {
        public static Serilog.ILogger Log = Serilog.Log.Logger;        
    }

    public class LoggerAdapter<T> : IAppLogger<T> where T : class
    {
        private readonly Microsoft.Extensions.Logging.ILogger<T> _logger;
        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogStackTrace(string message, params object[] args)
        {
            _logger.LogTrace(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
