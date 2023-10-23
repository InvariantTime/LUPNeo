using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public sealed class SceneObject : DisposableObject, IComponentProvider
    {
        private readonly ComponentScope components;

        public IComponentScope Components => components;

        public bool IsInitialized { get; private set; }

        public TransformComponent Transform { get; }

        internal IObjectScope? Root { get; private set; }


        public SceneObject(IComponentPipeline componentInitialize)
        {
            components = new ComponentScope(componentInitialize, this);
            this.AddComponent(new TransformComponent());

            Transform = this.GetComponent<TransformComponent>()
              ?? throw new InvalidOperationException("Unable to regsiter transform");
        }


        public void Destroy()
        {
            Root?.Remove(this);
            Uninitialize();
        }


        internal void Initialize(IObjectScope root)
        {
            Root = root;
            IsInitialized = true;
        }


        internal void Uninitialize()
        {
            components.Destroy();
            IsInitialized = false;
        }
    }
}
