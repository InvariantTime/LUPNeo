namespace LUP.SceneGraph.Objects
{
    public interface IObjectProvider
    {
        IObjectScope GetObjects();
    }

    public interface IRootObjectProvider : IObjectProvider
    {
        IRootObjectScope GetRootObjects();
    }
}
