using LUP.SceneGraph.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components.Middlewares
{
    class InitializeTransformMiddleware : IComponentMiddleware
    {
        private readonly IScene scene;

        public ComponentOperations Operation => ComponentOperations.Initialize;

        public int Priority => 100;

        public InitializeTransformMiddleware(IScene scene)
        {
            this.scene = scene;
        }


        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            if (context.Component is TransformComponent transform)
            {
                var scope = scene.GetRootObjects().AddChild(context.Owner);

                if (scope == null)
                    throw new Exception("Unable to register transform");

                transform.InitializeTransform(scope);
            }

            next.Invoke(context);
        }
    }
}
