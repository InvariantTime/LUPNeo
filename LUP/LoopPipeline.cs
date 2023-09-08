namespace LUP
{
    public class LoopPipeline : ILoopPipeline
    {
        private readonly Stack<IApplicationStage> stages = new();

        public void AddStage(IApplicationStage stage)
        {
            if (stages.First(x => x.GetType() == stage.GetType()) != null)
                throw new ArgumentException("There is already such stage", nameof(stage));

            stages.Push(stage);
        }

        public void Run(LoopContext context)
        {
            foreach (var stage in stages)
                stage.Handle(context);
        }

        
        public void Dispose()
        {
            foreach (var stage in stages)
            {
                if (stage is IDisposable d)
                {
                    d.Dispose();
                }
                else if (stage is IAsyncDisposable ad)
                {
                    ad.DisposeAsync().GetAwaiter();
                }
            }
        }


        public async ValueTask DisposeAsync()
        {
            foreach (var stage in stages)
            {
                if (stage is IAsyncDisposable ad)
                {
                    await ad.DisposeAsync();
                }
                else if (stage is IDisposable d)
                {
                    d.Dispose();
                }
            }
        }
    }
}