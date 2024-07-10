using LUP.SceneGraph.Components;

namespace LUP.SceneGraph
{
    static class SceneInternalExtensions
    {
        public static void Uninitialize(this IComponentCollection collection)
        {
            while (collection.Count > 0)
            {
                var component = collection.First();
                collection.RemoveComponent(component);
            }
        }
    }
}