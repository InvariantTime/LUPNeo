using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph.Objects
{
    public interface IObjectScope : IReadOnlyCollection<SceneObject>
    {
        //TODO: descriptor for object
        SceneObject Instantiate(ISceneObjectDescriptor? descriptor);

        void Remove(SceneObject @object);
    }
}
