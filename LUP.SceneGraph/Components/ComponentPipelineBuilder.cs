using LUP.Logging;
using System.Collections.Immutable;

namespace LUP.SceneGraph.Components
{
    public class ComponentPipelineBuilder
    {
        private static readonly Action<ComponentContext> terminal = (_) => { };

        private readonly List<MiddlewareDescription> descriptions;
        private readonly ILogger<ComponentPipeline> logger;

        public ComponentPipelineBuilder(IEnumerable<IComponentMiddleware> middlewares, ILogger<ComponentPipeline> logger)
        {
            descriptions = middlewares.Select(x => new MiddlewareDescription
            {
                Action = x.Execute,
                Operation = x.Operation,
                Priority = x.Priority
            }).ToList();

            this.logger = logger;
        }


        public void AddMiddleware(Action<ComponentContext, Action<ComponentContext>> action, ComponentOperations operation, int priority = 100)
        {
            descriptions.Add(new MiddlewareDescription
            {
                Action = action,
                Operation = operation,
                Priority = priority
            });
        }


        public IComponentPipeline Build()
        {
            ImmutableDictionary<ComponentOperations, Action<ComponentContext>> dic = descriptions
                .GroupBy(x => x.Operation).ToImmutableDictionary(x => x.Key, BuildAction);

            var action = (ComponentContext context, ComponentOperations op) =>
            {
                bool result = dic.TryGetValue(op, out var ac);

                if (result == true)
                    ac?.Invoke(context);
            };

            return new ComponentPipeline(action, logger);
        }


        private static Action<ComponentContext> BuildAction(IEnumerable<MiddlewareDescription> descriptions)
        {
            var order = descriptions.OrderByDescending(x => x.Priority);

            Action<ComponentContext> Chain(Action<ComponentContext> next, MiddlewareDescription description)
            {
                return (c) =>
                {
                    description.Action.Invoke(c, next);
                };
            }

            var current = terminal;

            for (int i = 0; i < order.Count(); i++)
                current = Chain(current, order.ElementAt(i));


            return current;
        }
    }


    readonly struct MiddlewareDescription
    {
        public Action<ComponentContext, Action<ComponentContext>> Action { get; init; }

        public int Priority { get; init; }

        public ComponentOperations Operation { get; init; }
    }
}
