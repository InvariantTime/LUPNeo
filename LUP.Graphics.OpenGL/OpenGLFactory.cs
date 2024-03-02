using LUP.Graphics.OpenGL.Resources;
using LUP.Graphics.Resources;
using System.Collections.ObjectModel;

namespace LUP.Graphics.OpenGL
{
    class OpenGLFactory : IResourceFactory, IDisposable
    {
        private readonly Dictionary<GraphicsResource, GLResource> resources;

        public IReadOnlyDictionary<GraphicsResource, GLResource> Resources { get; }

        public OpenGLFactory()
        {
            resources = new();
            Resources = new ReadOnlyDictionary<GraphicsResource, GLResource>(resources);
        }


        public void BuildBuffer(DataBufferDescriptor descriptor, GraphicsResource resource)
        {
            var type = OpenGLConverter.Convert(descriptor.Type);
            var buffer = new GLBuffer(type, descriptor.Data);
            AddAndValidateResource(buffer, resource, GraphicsResourceTypes.Buffer);
        }


        public void BuildConstantBuffer(ConstantBufferDescriptor descriptor, GraphicsResource resource)
        {
            var buffer = new GLUniformBuffer(descriptor.Size, descriptor.Index);
            AddAndValidateResource(buffer, resource, GraphicsResourceTypes.Buffer);
        }


        public void BuildRenderTarget(RenderTargetDescriptor descriptor, GraphicsResource resource)
        {
            var fbo = new GLRenderTarget(descriptor);
            AddAndValidateResource(fbo, resource, GraphicsResourceTypes.RenderTarget);
        }


        public void BuildTexture(TextureDescriptor descriptor, GraphicsResource resource)
        {
            var texture = new GLTexture(descriptor);
            AddAndValidateResource(texture, resource, GraphicsResourceTypes.Texture);
        }


        public void BuildShader(ShaderDescriptor descriptor, GraphicsResource resource)
        {
            var shader = ShaderBuilder.Build(descriptor);
            AddAndValidateResource(shader, resource, GraphicsResourceTypes.Shader);
        }


        public void DestroyResource(GraphicsResource resource)
        {
            resources.Remove(resource);
        }


        public void Dispose()
        {
            foreach (var res in resources)
                res.Value.Dispose();

            resources.Clear();
        }


        public GLResource? GetResource(GraphicsResource resource)
        {
            resources.TryGetValue(resource, out var res);
            return res;
        }


        private void AddAndValidateResource(GLResource resource, GraphicsResource reference, GraphicsResourceTypes type)
        {
            if (reference.Type != type)
                throw new InvalidCastException("Reference has invalid type");

            resources.TryAdd(reference, resource);
        }
    }
}
