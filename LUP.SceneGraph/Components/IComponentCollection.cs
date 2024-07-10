namespace LUP.SceneGraph.Components
{
    public interface IComponentCollection : IReadOnlyCollection<ObjectComponentBase>
    {
        void AddComponent(ObjectComponentBase component);

        void RemoveComponent(ObjectComponentBase component);

        T? GetComponent<T>() where T : class;
    }
}