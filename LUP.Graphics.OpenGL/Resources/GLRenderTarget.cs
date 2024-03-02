using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLRenderTarget : GLResource
    {
        private readonly int index;

        public GLRenderTarget(RenderTargetDescriptor descriptor)
        {
            index = GL.GenFramebuffer();
        }


        public override void Bind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, index);
        }


        public override void Unbind()
        {
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        }


        public override void Dispose()
        {
            GL.DeleteFramebuffer(index);
        }


        public override int GetIndex()
        {
            return index;
        }
    }
}
