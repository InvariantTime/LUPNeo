using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using System.Collections;

namespace LUP.SceneGraph.Implementation
{
    sealed class ComponentCollection : IComponentCollection
    {
        private readonly List<ObjectComponentBase> _components;
        private readonly ComponentRegister _register;
        private SceneObject? _object;

        public int Count => _components.Count;

        public ComponentCollection(ComponentRegister register)
        {
            _components = new();
            _register = register;
        }

        public void AddComponent(ObjectComponentBase component)
        {
            if (_object == null)
                throw new Exception("Collection is not initialized");

            _components.Add(component);
            _register.Register(component, _object);
        }

        public void RemoveComponent(ObjectComponentBase component)
        {
            if (_object == null)
                throw new Exception("Collection is not initialized");

            bool result = _components.Remove(component);

            if (result == true)
                _register.Unregister(component, _object);
        }

        public T? GetComponent<T>() where T : class
        {
            return _components.FirstOrDefault(x => x is T) as T;
        }

        public IEnumerator<ObjectComponentBase> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        public void SetObject(SceneObject @object)
        {
            if (@object == null)
                throw new Exception("Object cannot be null");

            _object = @object;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _components.GetEnumerator();
        }
    }
}