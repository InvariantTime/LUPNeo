using LUP.App.Contexts;

namespace LUP.App
{
    public delegate void AppLoopMiddleware(LoopContext context);

    public interface IApplicationLoop
    {
        AppLoopMiddleware Initialize { get; }

        AppLoopMiddleware Shutdown { get; }

        Task UpdateAsync(LoopContext context);
    }
}
