using LUP.SceneGraph.Components.Attribs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components.Middlewares
{
    class RemoveValidationMiddleware : IComponentMiddleware
    {
        public ComponentOperations Operation => ComponentOperations.Uninitialize;

        public int Priority => 0;

        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            if (context.Component == null)
                throw new InvalidOperationException("Unable to remove null component");

            if (Attribute.IsDefined(context.Component.GetType(), typeof(ServiceComponentAttribute)) == true
                && context.DestroingObject == false)
            {
                throw new InvalidOperationException($"Unable to remove {context.Component.GetType().FullName}");
            }

            if (context.Owner.Components.Contains(context.Component) == false)
                throw new InvalidOperationException("There is no such component");

            next.Invoke(context);
        }
    }
}
