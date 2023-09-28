using LUP.SceneGraph.Descriptors;
using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
