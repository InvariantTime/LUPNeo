
namespace LUP.App
{
    public interface IApplication
    {
        IServiceProvider Services { get; }

        internal ApplicationLoopBuilder LoopBuilder { get; }

        Task RunAsync(CancellationToken token);
    }
}