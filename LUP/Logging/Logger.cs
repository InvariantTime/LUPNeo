using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Logging
{
    public class Logger<T> : ILogger
    {
        private readonly IEnumerable<ILoggerService> services;
        private readonly string name;

        public Logger(IEnumerable<ILoggerService> service)
        {
            name = ;
        }


        public void Message(string message, LogLevel level, Exception? exception = null)
        {
            service.Message(new LogMessage
            {
                Exception = exception,
                Level = level,
                Message = message,
                Source = name,
                Time = DateTime.Now
            });
        }
    }
}
