using LUP.Graphics.OpenGL.RenderTargets;
using LUP.Graphics.OpenGL.Textures;
using LUP.Graphics.Rendertargets;
using LUP.Math;

namespace LUP.Graphics.OpenGL.Factories
{
    static class GLFrameBufferFactory
    {
        public static IFrameBuffer Build(FrameBufferDescriptor descriptor)
        {
            var depth = CreateTexture(descriptor.Size, descriptor.DepthStencil);
            var colors = descriptor.Colors.Select(x => CreateTexture(descriptor.Size, x));

            return new FrameBuffer(descriptor.Size, depth, colors);
        }


        private static GLFBOTexture? CreateTexture(Vector2 size, FBOTextureDescriptor? descriptor)
        {
            if (descriptor == null)
                return null;

            var texture = new EmptyTexture(size, descriptor.Type, descriptor.Format);
            return new GLFBOTexture(texture);
        }
    }
}
