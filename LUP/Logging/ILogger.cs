namespace LUP.Logging
{
    public interface ILogger<T>
    {
        void Message(string message, LogLevel level, Exception? exception = null);
    }
}
