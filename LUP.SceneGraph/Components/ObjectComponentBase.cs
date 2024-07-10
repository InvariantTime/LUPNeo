using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph.Components
{
    public abstract class ObjectComponentBase
    {
        private SceneObject? _object;

        public bool IsInitialized => _object != null;

        internal SceneObject Object => _object
            ?? throw new Exception("Component is not initialized");

        protected abstract void OnInitialize();

        protected abstract void OnUninitialize();

        protected void AddComponent(ObjectComponentBase component)
        {
            Object.Components.AddComponent(component);
        }

        protected void RemoveComponent(ObjectComponentBase component)
        {
            Object.Components.RemoveComponent(component);
        }

        internal void Initialize(SceneObject @object)
        {
            _object = @object
                ?? throw new Exception("object cannot be null");

            OnInitialize();
        }

        internal void Uninitialize()
        {
            OnUninitialize();
            _object = null;
        }
    }
}