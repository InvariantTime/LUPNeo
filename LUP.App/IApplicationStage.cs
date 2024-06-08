using LUP.App.Contexts;

namespace LUP.App
{
    public interface IApplicationStage : IDisposable, IAsyncDisposable
    {
        void Update(LoopContext context);
    }
}
