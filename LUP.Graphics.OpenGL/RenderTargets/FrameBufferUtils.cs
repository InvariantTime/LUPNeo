using LUP.Graphics.Enums;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.RenderTargets
{
    static class FrameBufferUtils
    {
        public static void BindTexture(TextureTypes type, FramebufferAttachment attachment, int index, int level)
        {
            GL.FramebufferTexture2D(FramebufferTarget.Framebuffer, attachment, OpenGLConverter.Convert(type),
                index, level);
        }
    }
}
