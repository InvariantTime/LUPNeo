using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph.Components
{
    public class ObjectComponent : ObjectComponentBase
    {
        private TransformComponent? transform;

        public TransformComponent Transform => transform
            ?? throw new Exception("component is not initialized");

        protected virtual void Awake()
        {
        }

        protected sealed override void OnInitialize()
        {
            transform = Object.Transform;
            Awake();
        }

        protected SceneObject Instantiate()
        {
            return Transform.Instantiate();
        }

        protected SceneObject InstantiateChild()
        {
            return Transform.InstantiateChild();
        }

        protected override void OnUninitialize()
        {
        }
    }
}