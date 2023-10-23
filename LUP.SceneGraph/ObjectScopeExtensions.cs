using LUP.SceneGraph.Descriptors;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph
{
    public static class ObjectScopeProviderExtensions
    {
        public static SceneObject Instantiate(this IObjectProvider provider)
        {
            return provider.GetObjects().Instantiate(null);
        }


        public static SceneObject Instantiate(this IObjectProvider provider, ISceneObjectDescriptor descriptor)
        {
            return provider.GetObjects().Instantiate(descriptor);
        }
    }
}
