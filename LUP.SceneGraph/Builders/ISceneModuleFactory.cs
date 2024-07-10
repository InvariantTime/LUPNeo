using LUP.SceneGraph.Modules;

namespace LUP.SceneGraph.Builders
{
    public interface ISceneModuleFactory
    {
        ISceneModuleScope Build(IComponentPipelineBuilder builder);
    }
}