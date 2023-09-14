namespace LUP.DependencyInjection
{
    public interface IServiceScope : IDisposable, IAsyncDisposable
    {
        IServiceProvider Services { get; }
    }
}
