using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using LUP.SceneGraph.Scenes;
using System.Collections;
using System.Collections.Concurrent;

namespace LUP.SceneGraph.Implementation
{
    sealed class SceneCollection : ISceneCollection
    {
        private readonly ConcurrentDictionary<long, SceneObject> _objects;
        private readonly ComponentRegister _register;
        private readonly ObjectDestructor _deregister;

        public SceneCollection(IComponentPipeline pipeline)
        {
            _objects = new();
            _register = new(this, pipeline);
            _deregister = new(this);
        }

        public SceneObject Instantiate()
        {
            TransformComponent transform = new();
            long id = GenerateId();

            var components = new ComponentCollection(_register);
            var @object = new SceneObject(id, transform, components);

            components.SetObject(@object);
            components.AddComponent(transform);

            _objects.TryAdd(id, @object);

            return @object;
        }

        public bool Remove(long id)
        {
            _objects.TryGetValue(id, out var @object);

            if (@object == null)
                return false;

            return _deregister.Destruct(@object);
        }

        public IEnumerator<SceneObject> GetEnumerator()
        {
            return _objects.Values.GetEnumerator();
        }

        public bool RemoveInternal(long id)
        {
            return _objects.TryRemove(id, out _);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _objects.Values.GetEnumerator();
        }

        private long GenerateId()
        {
            long id;

            do
            {
                id = Random.Shared.NextInt64(long.MaxValue);
            }
            while (_objects.ContainsKey(id) == true);

            return id;
        }
    }
}