namespace LUP.Logging
{
    public struct LogMessage
    {
        public string? Message { get; set; }

        public Exception? Exception { get; set; }

        public LogLevel Level { get; set; }

        public DateTime Time { get; set; }

        public string? Source { get; set; }
    }

    public enum LogLevel
    {
        Debug = 0,

        Info = 1,

        Warn = 2,

        Error = 3,

        Fatal = 4
    }
}
