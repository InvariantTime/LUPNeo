using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph.Objects
{
    public interface IObjectBuilder
    {
        SceneObject Build(IObjectScope scope, ISceneObjectDescriptor? descriptor);
    }
}
