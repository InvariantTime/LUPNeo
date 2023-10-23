using LUP.Logging;
using LUP.SceneGraph.Descriptors;
using System.Collections;
using System.Collections.ObjectModel;

namespace LUP.SceneGraph.Objects
{
    public interface IRootObjectScope : IObjectScope
    {
        IReadOnlyDictionary<SceneObject, IObjectScope> Children { get; }

        IObjectScope? AddChild(SceneObject owner);

        void RemoveChild(SceneObject owner);
    }

    class RootObjectScope : IRootObjectScope
    {
        private readonly ILogger<RootObjectScope> logger;
        private readonly IObjectBuilder builder;
        private readonly List<SceneObject> objects;
        private readonly Dictionary<SceneObject, IObjectScope> children;

        public IReadOnlyDictionary<SceneObject, IObjectScope> Children =>
            new ReadOnlyDictionary<SceneObject, IObjectScope>(children);

        public int Count => objects.Count;

        public RootObjectScope(IObjectBuilder builder, ILogger<RootObjectScope> logger)
        {
            this.builder = builder;
            this.logger = logger;

            objects = new();
            children = new();
        }


        public SceneObject Instantiate(ISceneObjectDescriptor? descriptor)
        {
            var result = builder.Build(this, descriptor);
            objects.Add(result);

            return result;
        }


        public void Remove(SceneObject @object)
        {
            bool result = objects.Remove(@object);

            if (result == false)
            {
                logger.Warn($"There is no such object {@object}");
                return;
            }

            @object.Uninitialize();
        }


        public IEnumerator<SceneObject> GetEnumerator()
        {
            return objects.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return objects.GetEnumerator();
        }


        public IObjectScope? AddChild(SceneObject owner)
        {
            if (children.ContainsKey(owner) == true)
                return null;

            var scope = new TransformObjectScope(owner, builder);
            children.Add(owner, scope);

            return scope;
        }


        public void RemoveChild(SceneObject owner)
        {
            bool result = children.Remove(owner);

            if (result == false)
                logger.Error("Object scope was not finded");
        }
    }
}
