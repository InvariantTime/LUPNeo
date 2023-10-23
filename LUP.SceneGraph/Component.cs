using LUP.SceneGraph.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public class Component : ComponentBase
    {
        private TransformComponent transform = TransformComponent.Nullable;

        public TransformComponent Transform => transform;

        protected sealed override void OnInitialized()
        {
            transform = GetComponent<TransformComponent>()
                ?? throw new InvalidOperationException("Object has not transform");
        }


        protected sealed override void OnUnitialized()
        {
            transform = TransformComponent.Nullable;
        }


        protected SceneObject Instantiate()
        {
            if (IsInitialized == false)
                throw new InvalidOperationException("component is not initialized");

            return Scene!.Instantiate();
        }
    }
}
