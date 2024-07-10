using LUP.SceneGraph.Contexts;
using LUP.Utils;

namespace LUP.SceneGraph.Components
{
    public interface IComponentPipeline
    {
        Result Initialize(ComponentPipelineContext context);

        Result Uninitialize(ComponentPipelineContext context);
    }
}