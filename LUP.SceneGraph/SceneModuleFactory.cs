using LUP.SceneGraph.Builders;
using LUP.SceneGraph.Implementation;
using LUP.SceneGraph.Modules;

namespace LUP.SceneGraph
{
    public class SceneModuleFactory : ISceneModuleFactory
    {
        private readonly List<Func<ISceneModule>> _modules = new();

        public void AddBuilder(Func<ISceneModule> builder)
        {
            _modules.Add(builder);
        }

        public ISceneModuleScope Build(IComponentPipelineBuilder builder)
        {
            var modules = new List<ISceneModule>();

            foreach (var factory in _modules)
            {
                var module = factory.Invoke();
                module.ConfigurePipeline(builder);

                modules.Add(module);
            }

            return new SceneModuleScope(modules);
        }
    }
}