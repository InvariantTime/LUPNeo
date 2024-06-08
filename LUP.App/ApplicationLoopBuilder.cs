
namespace LUP.App
{
    class ApplicationLoopBuilder
    {
        private static readonly AppLoopMiddleware terminal = (_) => { };

        private readonly Queue<IApplicationModule> modules;
        private readonly Queue<IApplicationStage> stages;

        public ApplicationLoopBuilder()
        {
            modules = new();
            stages = new();
        }


        public void AddModule(IApplicationModule module)
        {
            modules.Enqueue(module);
        }


        public void AddStage(IApplicationStage stage)
        {
            stages.Enqueue(stage);
        }


        public IApplicationLoop Build()
        {
            var initialize = CreateChain(modules.Select(x => (AppLoopMiddleware)x.OnInitialize));
            var shutdown = CreateChain(modules
                .Reverse().Select(x => (AppLoopMiddleware)x.OnShutdown));

            return new ApplicationLoop(initialize, shutdown, stages);
        }


        private AppLoopMiddleware CreateChain(IEnumerable<AppLoopMiddleware> middlewares)
        {
            AppLoopMiddleware Chain(AppLoopMiddleware next, AppLoopMiddleware current)
            {
                return (context) =>
                {
                    current.Invoke(context);
                    next.Invoke(context);
                };
            }

            var current = terminal;

            foreach (var middleware in middlewares)
                current = Chain(middleware, current);
            
            return current;
        }
    }
}
