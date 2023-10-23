using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph
{
    interface ISceneBuilder
    {
        SceneProvider BuildScene(ISceneDescriptor? descriptor);
    }
}
