using LUP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Components
{
    public class ComponentPipeline : IComponentPipeline
    {
        private readonly Action<ComponentContext, ComponentOperations> action;
        private readonly ILogger<ComponentPipeline> logger;

        public ComponentPipeline(Action<ComponentContext, ComponentOperations> action,
            ILogger<ComponentPipeline> logger)
        {
            this.action = action;
            this.logger = logger;
        }


        public bool Handle(ComponentContext context, ComponentOperations operation) 
        {
            try
            {
                action?.Invoke(context, operation);
            }
            catch(Exception ex)
            {
                logger.Error($"Unable to register component {context.Component}", ex);
                return false;
            }

            return true;
        }
    }
}
