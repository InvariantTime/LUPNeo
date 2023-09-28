using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public sealed class ComponentMiddleware : IComponentMiddleware
    {
        private readonly Action<ComponentContext> body;

        public ComponentOperations Operation { get; }

        public int Priority { get; set; }

        public ComponentMiddleware(ComponentOperations operation, int priority, Action<ComponentContext> action)
        {
            Operation = operation;
            Priority = priority;
            body = action;
        }


        public void Execute(ComponentContext context, Action<ComponentContext> next)
        {
            body.Invoke(context);
            next.Invoke(context);
        }
    }
}
