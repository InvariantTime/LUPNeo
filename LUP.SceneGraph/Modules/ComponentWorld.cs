using LUP.SceneGraph.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Modules
{
    public abstract class ComponentWorld<T> : InitializeModule where T : class
    {
        private readonly HashSet<T> components;

        public ComponentWorld()
        {
            components = new();
        }


        protected virtual void OnAdding(T component)
        {
        }


        protected virtual void OnRemoving(T component)
        {
        }


        protected virtual bool IsValid(T component)
        {
            return true;
        }


        protected sealed override void OnInitializeComponent(ComponentContext context)
        {
            if (context.Component is T component)
            {
                if (IsValid(component) == false)
                    return;

                bool result = components.Add(component);

                if (result == true)
                    OnAdding(component);
            }
        }


        protected sealed override void OnUninitializeComponent(ComponentContext context)
        {
            if (context.Component is T component)
            {
                bool result = components.Remove(component);

                if (result == true)
                    OnRemoving(component);
            }
        }
    }
}
