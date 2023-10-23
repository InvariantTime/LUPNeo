namespace LUP.SceneGraph.Modules
{
    public interface IModuleScope : IReadOnlyCollection<SceneModule>
    {
        T? GetModule<T>() where T : SceneModule;
    }
}
