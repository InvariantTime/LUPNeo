using LUP.DependencyInjection;
using LUP.SceneGraph.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph
{
    public class SceneBuilder : ISceneBuilder
    {
        private readonly IScopeFactory factory;

        public SceneBuilder(IScopeFactory factory)
        {
            this.factory = factory;
        }

        public SceneProvider BuildScene(ISceneDescriptor? descriptor)
        {
            var scope = factory.CreateScope();

            if (scope == null)
                throw new InvalidOperationException("Unable to create scope");

            var scene = scope.GetService<IScene>();

            if (scene == null)
                throw new InvalidOperationException("Unable to create scene");

            if (descriptor != null)
                descriptor.Visit(scene);

            return new SceneProvider(scope, scene);
        }
    }
}
