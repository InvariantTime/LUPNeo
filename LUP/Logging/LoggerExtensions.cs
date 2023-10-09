namespace LUP.Logging
{
    public static class LoggerExtensions
    {
        public static void Info<T>(this ILogger<T> logger, string message)
        {
            logger.Message(message, LogLevel.Info);
        }


        public static void Warn<T>(this ILogger<T> logger, string message)
        {
            logger.Message(message, LogLevel.Warn);
        }


        public static void Error<T>(this ILogger<T> logger, string message, Exception? exception = null)
        {
            logger.Message(message, LogLevel.Error, exception);
        }


        public static void Fatal<T>(this ILogger<T> logger, string message, Exception? exception = null)
        {
            logger.Message(message, LogLevel.Fatal, exception);
        }


        public static void Debug<T>(this ILogger<T> logger, string message)
        {
            logger.Message(message, LogLevel.Debug);
        }
    }
}
