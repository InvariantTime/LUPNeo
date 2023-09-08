using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Logging
{
    public class Logger<T> : ILogger<T>
    {
        private readonly ImmutableList<ILoggerService> services;
        private readonly string name;

        public Logger(IEnumerable<ILoggerService> services)
        {
            this.services = services.ToImmutableList();
            name = typeof(T).Name;
        }


        public void Message(string message, LogLevel level, Exception? exception = null)
        {
            services.ForEach(service =>
            {
                service.Message(new LogMessage
                {
                    Exception = exception,
                    Level = level,
                    Message = message,
                    Source = name,
                    Time = DateTime.Now
                });
            });
        }
    }
}
