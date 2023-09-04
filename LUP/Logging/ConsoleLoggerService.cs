using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Logging
{
    public class ConsoleLoggerService : ILoggerService
    {
        private static readonly ConsoleColor defaultColor = ConsoleColor.White;

        private static readonly Dictionary<LogLevel, ConsoleColor> colorsMap = new()
        {
            [LogLevel.Debug] = ConsoleColor.Gray,
            [LogLevel.Info] = ConsoleColor.White,
            [LogLevel.Warn] = ConsoleColor.Yellow,
            [LogLevel.Error] = ConsoleColor.Red,
            [LogLevel.Fatal] = ConsoleColor.DarkRed
        };


        public void Message(LogMessage message)
        {
            Console.ForegroundColor = colorsMap[message.Level];

            var text = FormatText(message);
            Console.WriteLine(text);

            Console.ForegroundColor = defaultColor;
        }

        
        private static string FormatText(LogMessage message)
        {
            var source = $" {message.Source ?? string.Empty}:";
            var exception = message.Exception == null ? string.Empty : $"||{message.Exception}";
            return $"[{message.Level.ToString().ToUpper()}][{message.Time}]{source} {message.Message}{exception}";
        }
    }
}
