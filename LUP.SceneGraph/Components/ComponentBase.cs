using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public abstract class ComponentBase : DisposableObject
    {
        private SceneObject? owner;

        internal IScene? Scene { get; private set; }

        public bool IsInitialized { get; private set; }

        public void Destroy()
        {
            if (IsInitialized == false)
                return;

            owner!.Components.RemoveComponent(this);
        }


        protected virtual void OnInitialized()
        {
        }


        protected virtual void OnUnitialized()
        {
        }


        internal void Initialize(SceneObject owner, IScene scene)
        {
            this.owner = owner;
            Scene = scene;
            IsInitialized = true;

            OnInitialized();
        }


        internal void Uninitialize()
        {
            OnUnitialized();

            IsInitialized = false;
            owner = null;
            Scene = null;
        }
    }
}
