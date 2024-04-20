using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    //TODO: Rewrite textures
    class GLTexture : GLResource
    {
        private readonly int index;
        private readonly TextureTarget target;

        public GLTexture(TextureDescriptor descriptor)
        {
            index = GL.GenTexture();
            target = OpenGLConverter.Convert(descriptor.Type);

            GL.BindTexture(target, index);
            GL.TexImage2D(target, 0, PixelInternalFormat.Rgba, descriptor.Width, descriptor.Height, 0, 
                PixelFormat.Rgba, PixelType.UnsignedByte, descriptor.Data);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.TexParameter(target, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(target, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            GL.BindTexture(target, 0);
        }


        public override void Bind()
        {
            GL.BindTexture(target, index);
        }


        public override void Unbind()
        {
            GL.BindTexture(target, 0);
        }


        public override void Dispose()
        {
            GL.DeleteTexture(index);
        }


        public override int GetIndex()
        {
            return index;
        }
    }
}
