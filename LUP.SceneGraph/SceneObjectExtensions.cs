using LUP.SceneGraph.Components;

namespace LUP.SceneGraph
{
    public static class SceneObjectExtensions
    {
        public static T? GetComponent<T>(this SceneObject @object) where T : ComponentBase
        {
            return (T?)@object.Components.FirstOrDefault(x => x is T);
        }


        public static bool RemoveComponent(this SceneObject @object, ComponentBase component)
        {
            return @object.Components.RemoveComponent(component);
        }


        public static bool AddComponent(this SceneObject @object, ComponentBase component)
        {
            return @object.Components.AddComponent(component);
        }
    }
}
