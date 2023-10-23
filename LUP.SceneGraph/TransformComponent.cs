using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    [SingleComponent]
    public sealed partial class TransformComponent : ComponentBase, IObjectProvider
    {
        internal static readonly TransformComponent Nullable = new();

        private IObjectScope? children;

        internal TransformComponent()
        {
        }


        public IObjectScope GetObjects()
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("component is not initialized");

            return children!;
        }


        internal void InitializeTransform(IObjectScope children)
        {
            this.children = children;
        }


        internal void UninitializeTransform()
        {
            children = null;
        }
    }
}
