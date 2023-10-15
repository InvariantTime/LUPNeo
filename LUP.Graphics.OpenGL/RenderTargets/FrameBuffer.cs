using LUP.Graphics.Rendertargets;
using LUP.Math;
using OpenTK.Graphics.OpenGL;
using System.Collections.Immutable;

namespace LUP.Graphics.OpenGL.RenderTargets
{
    class FrameBuffer : DisposableObject, IFrameBuffer
    {
        private const int maxColors = 15;

        private readonly int index;

        public ImmutableArray<FBOTexture> Colors { get; }

        public FBOTexture? DepthStencil { get; }

        public Vector2 Size { get; }

        public FrameBuffer(Vector2 size, GLFBOTexture? depthStencil, IEnumerable<GLFBOTexture?> colors)
        {
            Size = size;

            index = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, index);

            if (depthStencil != null)
            {
                FrameBufferUtils.BindTexture(depthStencil.Texture.Type,
                    FramebufferAttachment.DepthStencilAttachment, depthStencil.TextureIndex, 0);
                DepthStencil = depthStencil;
            }

            var builder = ImmutableArray.CreateBuilder<FBOTexture>();

            for (int i = 0; i < colors.Count() && i < maxColors; i++)
            {
                var color = colors.ElementAt(i);

                if (color == null)
                    continue;

                FrameBufferUtils.BindTexture(color.Texture.Type,
                    FramebufferAttachment.ColorAttachment0 + i, color.TextureIndex, 0);
                builder.Add(color);
            }

            Colors = builder.ToImmutableArray();

            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }


        public void Bind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, index);
        }


        public void Unbind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }


        public void Resize(Vector2 size)
        {
        }
    }
}
