using LUP.App.Contexts;
using System.Collections.Immutable;

namespace LUP.App
{
    class ApplicationLoop : IApplicationLoop
    {
        private readonly ImmutableQueue<IApplicationStage> stages;

        public AppLoopMiddleware Initialize { get; }

        public AppLoopMiddleware Shutdown { get; }
      
        public ApplicationLoop(AppLoopMiddleware init, AppLoopMiddleware shutdown,
            IEnumerable<IApplicationStage> stages)
        {
            Initialize = init;
            Shutdown = shutdown;
            this.stages = ImmutableQueue.Create(stages.ToArray());
        }


        public Task UpdateAsync(LoopContext context)
        {
            foreach (var stage in stages)
                stage.Update(context);

            return Task.CompletedTask;
        }
    }
}
