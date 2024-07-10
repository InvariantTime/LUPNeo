using LUP.SceneGraph.Modules;
using LUP.SceneGraph.Scenes;

namespace LUP.SceneGraph.Implementation
{
    public class Scene : IScene
    {
        private readonly ISceneCollection _collection;
        private readonly ISceneModuleScope _modules;

        public ISceneModuleScope Modules => _modules;

        public Scene(ISceneCollection collection, ISceneModuleScope modules)
        {
            _collection = collection;
            _modules = modules;
        }

        public ISceneCollection GetObjects()
        {
            return _collection;
        }
    }
}