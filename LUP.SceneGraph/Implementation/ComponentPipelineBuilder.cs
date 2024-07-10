using LUP.SceneGraph.Builders;
using LUP.SceneGraph.Components;
using LUP.SceneGraph.Contexts;
using LUP.Utils;

namespace LUP.SceneGraph.Implementation
{
    sealed class ComponentPipelineBuilder : IComponentPipelineBuilder
    {
        private static readonly Func<ComponentPipelineContext, Result> _nonTerminal = (_) => Result.Success();

        private readonly Stack<ComponentMiddleware> _inits;
        private readonly Stack<ComponentMiddleware> _uinits;

        public ComponentPipelineBuilder()
        {
            _inits = new();
            _uinits = new();
        }

        public void AddMiddleware(ComponentMiddleware middleware, ComponentMiddlewareTypes type)
        {
            if (type == ComponentMiddlewareTypes.Init)
            {
                _inits.Push(middleware);
            }
            else if (type == ComponentMiddlewareTypes.Uinit)
            {
                _uinits.Push(middleware);
            }
        }

        public IComponentPipeline Build()
        {
            var init = MakeChain(_inits);
            var uinit = MakeChain(_uinits);

            return new ComponentPipeline(init, uinit);
        }

        private Func<ComponentPipelineContext, Result> MakeChain(IEnumerable<ComponentMiddleware> middlewares)
        {
            var current = _nonTerminal;

            static Func<ComponentPipelineContext, Result> Chain(ComponentMiddleware middleware, 
                Func<ComponentPipelineContext, Result> next)
            {
                return (context) =>
                {
                    return middleware.Invoke(context, next);
                };
            }

            foreach (var func in middlewares)
            {
                current = Chain(func, current);
            }

            return current;
        }
    }
}