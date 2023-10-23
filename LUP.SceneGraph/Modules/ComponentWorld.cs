using LUP.SceneGraph.Components;
using System.Collections.ObjectModel;

namespace LUP.SceneGraph.Modules
{
    //TODO: async
    public abstract class ComponentWorld<T> : InitializeModule where T : class
    {
        private readonly HashSet<T> components;

        public IReadOnlyCollection<T> Components => components;

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
