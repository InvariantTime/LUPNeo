using LUP.DependencyInjection;

namespace LUP
{
    public static class ApplicationExtensions
    {
        public static void AddStage<T>(this LApplication app) where T : IApplicationStage
        {
            var pipeline = app.Services.GetService<ILoopPipeline>() ?? throw new InvalidOperationException("Application has not loop");
            var stage = app.Services.GetService<T>() ?? throw new InvalidOperationException("There is no such stage");
            pipeline.AddStage(stage);
        }
    }
}
