namespace LUP
{
    public interface ILoopPipeline : IDisposable, IAsyncDisposable
    {
        void AddStage(IApplicationStage stage);

        void Run(LoopContext context);
    }
}
