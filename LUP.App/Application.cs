using LUP.App.Contexts;

namespace LUP.App
{
    class Application : IApplication
    {
        public IServiceProvider Services { get; }

        ApplicationLoopBuilder IApplication.LoopBuilder { get; } = new();

        public Application(IServiceProvider services)
        {
            Services = services;
        }


        public async Task RunAsync(CancellationToken token)
        {
            var context = new LoopContext();

            var loop = ((IApplication)this).LoopBuilder.Build();
            loop.Initialize.Invoke(context);

            while (token.IsCancellationRequested == false && context.IsLoop == true)
            {
                await loop.UpdateAsync(context);
            }

            loop.Shutdown.Invoke(context);
        }
    }
}
