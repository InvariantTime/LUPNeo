using LUP.SceneGraph.Components;
using LUP.SceneGraph.Contexts;
using LUP.Utils;

namespace LUP.SceneGraph.Builders
{
    public delegate Result ComponentMiddleware(ComponentPipelineContext context, Func<ComponentPipelineContext, Result> next);

    public enum ComponentMiddlewareTypes
    {
        Init,
        Uinit
    }

    public interface IComponentPipelineBuilder
    {
        void AddMiddleware(ComponentMiddleware middleware, ComponentMiddlewareTypes type);

        IComponentPipeline Build();
    }
}