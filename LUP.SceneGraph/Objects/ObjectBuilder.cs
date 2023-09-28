using LUP.Logging;
using LUP.SceneGraph.Components;
using LUP.SceneGraph.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.SceneGraph.Objects
{
    public class ObjectBuilder : IObjectBuilder
    {
        private readonly IComponentPipeline pipeline;

        public ObjectBuilder(IComponentPipeline pipeline)
        {
            this.pipeline = pipeline;
        }


        public SceneObject Build(IObjectScope scope, ISceneObjectDescriptor? descriptor)
        {
            var result = new SceneObject(pipeline);
            result.Initialize(scope);

            if (descriptor != null)
                descriptor.Handle(result);

            if (result.IsInitialized == false)
                throw new InvalidOperationException("Unable to initialize object");

            return result;
        }
    }
}
