namespace LUP.SceneGraph.Components
{
    public abstract class ComponentBase : DisposableObject
    {
        private SceneObject? owner;

        internal IScene? Scene { get; private set; }

        public bool IsInitialized { get; private set; }

        public void Destroy()
        {
            if (IsInitialized == false)
                return;

            owner!.Components.RemoveComponent(this);
        }


        protected virtual void OnInitialized()
        {
        }


        protected virtual void OnUnitialized()
        {
        }


        protected T? GetComponent<T>() where T : ComponentBase
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("Component is not initialized");

            return owner!.GetComponent<T>();
        }


        internal void Initialize(SceneObject owner, IScene scene)
        {
            this.owner = owner;
            Scene = scene;
            IsInitialized = true;

            OnInitialized();
        }


        internal void Uninitialize()
        {
            OnUnitialized();

            IsInitialized = false;
            owner = null;
            Scene = null;
        }


        internal SceneObject? GetOwner()
        {
            return owner;
        }
    }
}
