using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph
{
    public interface ISceneProcessor : IApplicationStage
    {
        SceneProvider? Provider { get; }

        void LoadScene(ISceneDescriptor? descriptor);
    }
}
