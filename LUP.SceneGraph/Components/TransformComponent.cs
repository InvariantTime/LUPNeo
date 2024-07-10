using LUP.SceneGraph.Objects;
using LUP.SceneGraph.Scenes;

namespace LUP.SceneGraph.Components
{
    public sealed class TransformComponent : ObjectComponentBase
    {
        private readonly List<TransformComponent> _childern = new();

        private ISceneCollection? _root;

        public TransformComponent? Parent { get; private set; }

        internal ISceneCollection Root => _root
            ?? throw new Exception("Transform is not initialized");

        public void BindParent(TransformComponent parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent), "parent cannot be null");
            
            if (parent == this)
                throw new Exception("Transform cannot bind to itself");

            if (parent.InBranchOf(this) == true)
                throw new Exception("Transform cannot make cycles");

            if (Parent != null)
                UnbindParent();

            Parent = parent;
            parent.AddChildInternal(this);
        }

        public void UnbindParent()
        {
            if (Parent == null)
                return;

            Parent.RemoveChildInternal(this);
            Parent = null;
        }

        protected override void OnInitialize()
        {
        }

        protected override void OnUninitialize()
        {
            _root = null;

            if (Parent != null)
            {
                UnbindParent();
            }
        }

        internal void InitializeTransform(ISceneCollection collection)
        {
            _root = collection
                ?? throw new ArgumentNullException(nameof(collection));
        }

        private void AddChildInternal(TransformComponent child)
        {
            _childern.Add(child);
        }

        private void RemoveChildInternal(TransformComponent child)
        {
            _childern.Remove(child);
        }
    }
}