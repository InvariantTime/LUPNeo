using LUP.SceneGraph.Components;

namespace LUP.SceneGraph.Objects
{
    public sealed class SceneObject
    {
        public TransformComponent Transform { get; }

        public IComponentCollection Components { get; }

        public long Id { get; }

        internal SceneObject(long id, TransformComponent transform, IComponentCollection components)
        {
            Id = id;
            Transform = transform;
            Components = components;
        }
    }
}