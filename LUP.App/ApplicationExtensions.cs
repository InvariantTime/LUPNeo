
namespace LUP.App
{
    public static class ApplicationExtensions
    {
        public static void AddModule(this IApplication application, IApplicationModule module)
        {
            application.LoopBuilder.AddModule(module);
        }


        public static void AddStage(this IApplication application, IApplicationStage stage)
        {
            application.LoopBuilder.AddStage(stage);
        }
    }
}