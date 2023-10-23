namespace LUP.SceneGraph.Components
{
    public interface IUpdatableComponent
    {
        void Update();
    }


    public interface IAsyncUpdatableComponent
    {
        Task Update();
    }
}
