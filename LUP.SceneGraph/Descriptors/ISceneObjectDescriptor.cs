namespace LUP.SceneGraph.Descriptors
{
    public interface ISceneObjectDescriptor
    {
        string Name { get; }

        void Handle(SceneObject @object);
    }
}
