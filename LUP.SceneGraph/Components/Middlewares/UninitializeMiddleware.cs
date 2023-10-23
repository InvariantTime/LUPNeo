namespace LUP.SceneGraph.Components.Middlewares
{
    class UninitializeMiddleware : IComponentMiddleware
    {
        private readonly IScene scene;

        public ComponentOperations Operation => ComponentOperations.Uninitialize;

        public int Priority => 10;

        public UninitializeMiddleware(IScene scene)
        {
            this.scene = scene;
        }

        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            next.Invoke(context);

            if (context.Component is TransformComponent transform)
            {
                foreach (var child in transform.GetObjects())
                    child.Destroy();

                transform.UninitializeTransform();
                scene.GetRootObjects().RemoveChild(context.Owner);
            }

            context.Component?.Uninitialize();
        }
    }
}
