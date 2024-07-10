using LUP.SceneGraph.Components;
using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph.Contexts
{
    public class ComponentPipelineContext<T> where T : class
    {
        public SceneObject Object { get; }

        public T Component { get; }

        public ComponentPipelineContext(SceneObject @object, T component) 
        {
            Object = @object;
            Component = component;
        }
    }

    public class ComponentPipelineContext : ComponentPipelineContext<ObjectComponentBase>
    {
        public ComponentPipelineContext(SceneObject @object, ObjectComponentBase component)
            : base(@object, component)
        {
        }
    }
}