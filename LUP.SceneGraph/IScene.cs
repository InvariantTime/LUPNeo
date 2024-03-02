using LUP.SceneGraph.Modules;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public interface IScene : IRootObjectProvider, IModuleProvider, IDisposable
    {
        bool IsInitialized { get; }

        //TODO: Scene scheduler
       // ISceneScheduler Scheduler { get; }
    }
}
