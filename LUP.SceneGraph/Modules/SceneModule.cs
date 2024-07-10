using LUP.SceneGraph.Builders;

namespace LUP.SceneGraph.Modules
{
    public abstract class SceneModule : ISceneModule
    {
        public virtual void ConfigurePipeline(IComponentPipelineBuilder builder)
        {
        }
    }
}