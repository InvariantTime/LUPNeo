namespace LUP.SceneGraph.Components.Middlewares
{
    class InitValidationMiddleware : IComponentMiddleware
    {
        public ComponentOperations Operation => ComponentOperations.Initialize;

        public int Priority => 0;

        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            var owner = context.Owner;
            var component = context.Component;

            if (component == null)
                throw new NullReferenceException("Component cannot be null");

            if (owner.Components.Contains(component) == true)
                throw new InvalidOperationException("There is already such component");

            next.Invoke(context);
        }
    }
}