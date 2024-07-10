using LUP.SceneGraph.Objects;

namespace LUP.SceneGraph.Scenes
{
    public interface ISceneCollection : IEnumerable<SceneObject>
    {
        SceneObject Instantiate();

        bool Remove(long id);
    }
}