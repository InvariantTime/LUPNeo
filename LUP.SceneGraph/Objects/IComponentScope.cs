using LUP.SceneGraph.Components;

namespace LUP.SceneGraph.Objects
{
    public interface IComponentProvider
    {
        IComponentScope Components { get; }
    }

    public interface IComponentScope : IReadOnlyCollection<ComponentBase>
    {
        bool AddComponent(ComponentBase component);

        bool RemoveComponent(ComponentBase component);
    }
}
