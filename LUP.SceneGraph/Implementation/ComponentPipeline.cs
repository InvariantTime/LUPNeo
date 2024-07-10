using LUP.SceneGraph.Components;
using LUP.SceneGraph.Contexts;
using LUP.Utils;

namespace LUP.SceneGraph.Implementation
{
    sealed class ComponentPipeline : IComponentPipeline
    {
        private readonly Func<ComponentPipelineContext, Result> _initAction;
        private readonly Func<ComponentPipelineContext, Result> _uinitAction;

        public ComponentPipeline(Func<ComponentPipelineContext, Result> initAction, 
            Func<ComponentPipelineContext, Result> uinitAction)
        {
            _initAction = initAction;
            _uinitAction = uinitAction;
        }

        public Result Initialize(ComponentPipelineContext context)
        {
            return _initAction.Invoke(context);
        }

        public Result Uninitialize(ComponentPipelineContext context)
        {
            return _uinitAction.Invoke(context);
        }
    }
}