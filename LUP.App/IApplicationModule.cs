using LUP.App.Contexts;

namespace LUP.App
{
    public interface IApplicationModule
    {
        void OnInitialize(LoopContext context);

        void OnShutdown(LoopContext context);
    }
}
