using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public static class TransformExtensions
    {
        public static bool InBranchOf(this TransformComponent transform, TransformComponent parent)
        {
            var current = transform;

            while (current.Parent != null)
            {
                if (current.Parent == parent)
                    return true;

                current = current.Parent;
            }

            return false;
        }

        public static bool IsChildOf(this TransformComponent chid, TransformComponent other)
        {
            return chid.Parent == other;
        }

        public static SceneObject Instantiate(this TransformComponent transform)
        {
            return transform.Root.Instantiate();
        }

        public static SceneObject InstantiateChild(this TransformComponent transform)
        {
            var obj = transform.Root.Instantiate();
            obj.Transform.BindParent(transform);

            return obj;
        }
    }
}