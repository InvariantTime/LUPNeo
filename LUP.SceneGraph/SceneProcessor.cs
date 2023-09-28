using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LUP.SceneGraph.Descriptors;

namespace LUP.SceneGraph
{
    class SceneProcessor : ISceneProcessor
    {
        private readonly ISceneBuilder builder;

        public SceneProvider? Provider { get; private set; }

        public SceneProcessor(ISceneBuilder builder)
        {
            this.builder = builder;
        }


        public void LoadScene(ISceneDescriptor? descriptor)
        {
            if (Provider != null)
                Provider.Scope.Dispose();

            Provider = builder.BuildScene(descriptor);
        }

        //TODO: scheduling
        public void Handle(LoopContext context)
        {
            if (Provider == null)
                return;

            var modules = Provider.Scene.GetModules();

            foreach(var module in modules)
            {
                module.Update();
            }
        }
    }
}
