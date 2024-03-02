using LUP.Graphics.Resources;
using System.Collections.Concurrent;

namespace LUP.Graphics
{
    public interface IResourceFactory
    {
        void BuildShader(ShaderDescriptor descriptor, GraphicsResource reference);

        void BuildTexture(TextureDescriptor descriptor, GraphicsResource reference);

        void BuildBuffer(DataBufferDescriptor descriptor, GraphicsResource reference);

        void BuildRenderTarget(RenderTargetDescriptor descriptor, GraphicsResource reference);

        void BuildConstantBuffer(ConstantBufferDescriptor descriptor, GraphicsResource reference);

        void DestroyResource(GraphicsResource resource);
    }
}
