using Microsoft.Extensions.Logging;
using NLog;
using ServiceLayer.Services.Interfaces;
using ILogger = NLog.ILogger;

namespace ServiceLayer.Services
{
    public class LoggerService : ILoggerService
    {
        private static ILogger _logger=LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
           _logger.Error(message);
        }

        public void LogInfo(string message)
        {
            _logger.Info(message);
        }

        public void LogResuestResponce(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);  
        }
    }
}
