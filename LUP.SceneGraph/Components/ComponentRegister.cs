using LUP.SceneGraph.Contexts;
using LUP.SceneGraph.Objects;
using LUP.SceneGraph.Scenes;

namespace LUP.SceneGraph.Components
{
    public sealed class ComponentRegister// TODO: Logging
    {
        private readonly IComponentPipeline _pipeline;
        private readonly ISceneCollection _collection;

        public ComponentRegister(ISceneCollection collection, IComponentPipeline pipeline)
        {
            _pipeline = pipeline;
            _collection = collection;
        }

        public void Register(ObjectComponentBase component, SceneObject @object)
        {

            if (component is TransformComponent transform)
            {
                transform.InitializeTransform(_collection);
            }

            var context = new ComponentPipelineContext(@object, component);

            _pipeline.Initialize(context);
            component.Initialize(@object);
        }

        public void Unregister(ObjectComponentBase component, SceneObject @object)
        {
            component.Uninitialize();

            if (component is TransformComponent transform)
            {
                transform.Uninitialize();
            }

            var context = new ComponentPipelineContext(@object, component);

            _pipeline.Uninitialize(context);
        }
    }
}