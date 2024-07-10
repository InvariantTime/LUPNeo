using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public static class SceneObjectExtensions
    {
        public static bool IsChildOf(this SceneObject @object, SceneObject other)
        {
            return @object.Transform.Parent == other.Transform;
        }

        public static void AddChild(this SceneObject @object, SceneObject other)
        {
            other.Transform.BindParent(@object.Transform);
        }

        public static void BindParent(this SceneObject @object, SceneObject other)
        {
            @object.Transform.BindParent(other.Transform);
        }
    }
}