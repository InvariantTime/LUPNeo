using LUP.SceneGraph.Components;
using System.Collections;

namespace LUP.SceneGraph.Objects
{
    sealed class ComponentScope : IComponentScope
    {
        private readonly IComponentPipeline pipeline;
        private readonly List<ComponentBase> components;
        private readonly SceneObject owner;

        public int Count => components.Count;

        public ComponentScope(IComponentPipeline pipeline, SceneObject owner)
        {
            this.pipeline = pipeline;
            this.owner = owner;

            components = new();
        }


        public bool AddComponent(ComponentBase component)
        {
            var context = new ComponentContext
            {
                Component = component,
                Owner = owner
            };

            bool result = pipeline.Handle(context, ComponentOperations.Initialize);

            if (result == true)
                components.Add(component);

            return result;
        }


        public bool RemoveComponent(ComponentBase component)
        {
            var context = new ComponentContext
            {
                Component = component,
                Owner = owner
            };

            bool result = pipeline.Handle(context, ComponentOperations.Uninitialize);

            if (result == true)
                components.Remove(component);

            return result;
        }


        public void Destroy()
        {
            var context = new ComponentContext
            {
                Owner = owner,
                DestroingObject = true
            };

            for (int i = 0; i < components.Count; i++)
            {
                context.Component = components[i];
                var result = pipeline.Handle(context, ComponentOperations.Uninitialize);

                if (result == true)
                {
                    components.Remove(components[i]);
                    i--;
                }
            }
        }


        public IEnumerator<ComponentBase> GetEnumerator()
        {
            return components.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
