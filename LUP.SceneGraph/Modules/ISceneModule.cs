using LUP.SceneGraph.Builders;

namespace LUP.SceneGraph.Modules
{
    public interface ISceneModule
    {
        void ConfigurePipeline(IComponentPipelineBuilder builder);
    }
}