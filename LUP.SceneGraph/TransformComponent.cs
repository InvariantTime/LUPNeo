using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    [SingleComponent]
    public sealed partial class TransformComponent : ComponentBase, IObjectProvider
    {
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
            this.children = null;
        }
    }
}
