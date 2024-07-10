using LUP.SceneGraph.Builders;
using LUP.SceneGraph.Implementation;
using LUP.SceneGraph.Scenes;

namespace LUP.SceneGraph
{
    public delegate void SceneStartupDelegate(IComponentPipelineBuilder builder);

    public class SceneBuilder : ISceneBuilder
    {
        private static readonly SceneStartupDelegate _emptyStartup = (_) => { };

        private readonly ISceneModuleFactory _factory;
        private readonly SceneStartupDelegate _startup;

        public SceneBuilder(ISceneModuleFactory factory)
            : this(factory, _emptyStartup)
        {
        }

        public SceneBuilder(ISceneModuleFactory factory, SceneStartupDelegate startup)
        {
            _factory = factory;
            _startup = startup;
        }

        public IScene Build()
        {
            var builder = new ComponentPipelineBuilder();
            _startup.Invoke(builder);

            var modules = _factory.Build(builder);
            var pipeline = builder.Build();

            var collection = new SceneCollection(pipeline);

            return new Scene(collection, modules);
        }
    }
}