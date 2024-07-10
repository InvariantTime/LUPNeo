using LUP.SceneGraph.Builders;
using LUP.SceneGraph.Contexts;

namespace LUP.SceneGraph
{
    public static class ComponentPipelineBuilderExtensions
    {
        public static IComponentPipelineBuilder InitFor<T>(this IComponentPipelineBuilder builder, 
            Action<ComponentPipelineContext<T>> action) where T : class
        {
            ForInternal<T>(builder, action, ComponentMiddlewareTypes.Init);
            return builder;
        }

        public static IComponentPipelineBuilder UinitFor<T>(this IComponentPipelineBuilder builder,
            Action<ComponentPipelineContext<T>> action) where T : class
        {
            ForInternal<T>(builder, action, ComponentMiddlewareTypes.Uinit);
            return builder;
        }

        private static void ForInternal<T>(IComponentPipelineBuilder builder, 
            Action<ComponentPipelineContext<T>> action, ComponentMiddlewareTypes type)
            where T : class
        {
            ComponentMiddleware func = (context, next) =>
            {
                if (context.Component is T component)
                {
                    var newContext = new ComponentPipelineContext<T>(context.Object, component);
                    action.Invoke(newContext);
                }
                
                return next.Invoke(context);
            };

            builder.AddMiddleware(func, type);
        }
    }
}