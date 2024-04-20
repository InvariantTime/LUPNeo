using LUP.Graphics.Resources;
using System.Collections.Concurrent;

namespace LUP.Graphics
{
    public interface IGraphicsAllocator
    {
        GraphicsResource BuildShader(ShaderDescriptor descriptor);

        GraphicsResource BuildTexture(TextureDescriptor descriptor);

        GraphicsResource BuildBuffer(DataBufferDescriptor descriptor);

        GraphicsResource BuildRenderTarget(RenderTargetDescriptor descriptor);

        GraphicsResource BuildConstantBuffer(ConstantBufferDescriptor descriptor);

        void DestroyResource(GraphicsResource resource);
    }


    sealed class GraphicsAllocator : IGraphicsAllocator
    {
        private static uint currentIndex = 1;

        private readonly ConcurrentBag<Action<IResourceFactory>> commands;

        public GraphicsAllocator()
        {
            commands = new();
        }


        public GraphicsResource BuildShader(ShaderDescriptor descriptor)
        {
            return CreateResource((f, r) => f.BuildShader(descriptor, r), GraphicsResourceTypes.Shader);
        }


        public GraphicsResource BuildTexture(TextureDescriptor descriptor)
        {
            return CreateResource((f, r) => f.BuildTexture(descriptor, r), GraphicsResourceTypes.Texture);
        }


        public GraphicsResource BuildBuffer(DataBufferDescriptor descriptor)
        {
            return CreateResource((f, r) => f.BuildBuffer(descriptor, r), GraphicsResourceTypes.Buffer);
        }


        public GraphicsResource BuildRenderTarget(RenderTargetDescriptor descriptor)
        {
            return CreateResource((f, r) => f.BuildRenderTarget(descriptor, r), GraphicsResourceTypes.RenderTarget);
        }


        public GraphicsResource BuildConstantBuffer(ConstantBufferDescriptor descriptor)
        {
            return CreateResource((f, r) => f.BuildConstantBuffer(descriptor, r), GraphicsResourceTypes.Buffer);
        }


        public void DestroyResource(GraphicsResource resource)
        {
            commands.Add(x => x.DestroyResource(resource));
        }


        internal void Execute(IResourceFactory factory)
        {
            foreach (var command in commands)
                command.Invoke(factory);
        }


        internal void Clear()
        {
            commands.Clear();
        }


        private GraphicsResource CreateResource(Action<IResourceFactory, GraphicsResource> func, GraphicsResourceTypes type)
        {
            var res = new GraphicsResource(currentIndex, type);
            currentIndex++;

            commands.Add((x) => func.Invoke(x, res));
            return res;
        }
    }
}
