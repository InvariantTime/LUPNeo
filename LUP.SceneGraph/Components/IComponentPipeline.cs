namespace LUP.SceneGraph.Components
{
    public interface IComponentPipeline
    {
        bool Handle(ComponentContext context, ComponentOperations operation);
    }
}
