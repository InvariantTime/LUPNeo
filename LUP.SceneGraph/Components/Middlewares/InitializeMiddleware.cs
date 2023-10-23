namespace LUP.SceneGraph.Components.Middlewares
{
    class InitializeComponentMiddleware : IComponentMiddleware
    {
        private readonly IScene scene;

        public ComponentOperations Operation => ComponentOperations.Initialize;

        public int Priority => 10;

        public InitializeComponentMiddleware(IScene scene)
        {
            this.scene = scene;
        }


        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            context.Component?.Initialize(context.Owner, scene);
            next.Invoke(context);
        }
    }
}
