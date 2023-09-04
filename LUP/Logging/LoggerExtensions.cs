using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Logging
{
    public static class LoggerExtensions
    {
        public static void Info(this ILogger logger, string message)
        {
            logger.Message(message, LogLevel.Info);
        }


        public static void Warn(this ILogger logger, string message)
        {
            logger.Message(message, LogLevel.Warn);
        }


        public static void Error(this ILogger logger, string message, Exception? exception = null)
        {
            logger.Message(message, LogLevel.Error, exception);
        }


        public static void Fatal(this ILogger logger, string message, Exception? exception = null)
        {
            logger.Message(message, LogLevel.Fatal, exception);
        }


        public static void Debug(this ILogger logger, string message)
        {
            logger.Message(message, LogLevel.Debug);
        }
    }
}
