using LUP.DependencyInjection;

namespace LUP.SceneGraph
{
    public sealed record SceneProvider(IServiceScope Scope, IScene Scene);
}