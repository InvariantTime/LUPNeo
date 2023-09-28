using LUP.SceneGraph.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Modules
{
    public abstract class InitializeModule : SceneModule, IComponentPipelineInitializer
    {
        public void Initialize(ComponentPipelineBuilder builder)
        {
            builder.AddMiddleware(OnInitializeComponent, ComponentOperations.Initialize);
            builder.AddMiddleware(OnUninitializeComponent, ComponentOperations.Uninitialize);
        }


        protected virtual void OnInitializeComponent(ComponentContext context)
        {
        }


        protected virtual void OnUninitializeComponent(ComponentContext context)
        {
        }


        private void OnInitializeComponent(ComponentContext context, Action<ComponentContext> next)
        {
            OnInitializeComponent(context);
            next.Invoke(context);
        }


        private void OnUninitializeComponent(ComponentContext context, Action<ComponentContext> next)
        {
            OnUninitializeComponent(context);
            next.Invoke(context);
        }
    }
}
