using LUP.DependencyInjection;

namespace LUP
{
    public sealed class LApplication : IDisposable, IAsyncDisposable
    {
        public static LApplication? Current { get; private set; }

        public IServiceProvider Services { get; }

        public ILoopPipeline Loop { get; }

        internal LApplication(IServiceProvider services)
        {
            if (Current != null)
                throw new InvalidOperationException("Application already created");

            Services = services;
            Loop = services.GetService<ILoopPipeline>() ?? throw new InvalidOperationException("Loop was not created");
        }


        public void Run()
        {
            var cancel = new CancellationTokenSource();
            var context = new LoopContext(cancel);

            while (cancel.IsCancellationRequested == false)
            {
                Loop.Run(context);
            }
        }


        public void Dispose()
        {
            if (Services is IDisposable d)
                d.Dispose();

            Loop.Dispose();
        }


        public async ValueTask DisposeAsync()
        {
            if (Services is IAsyncDisposable ad)
                await ad.DisposeAsync();

            await Loop.DisposeAsync();
        }
    }
}
