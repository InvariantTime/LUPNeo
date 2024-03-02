using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLTexture : GLResource
    {
        private readonly int index;
        private readonly TextureTarget target;

        public GLTexture(TextureDescriptor descriptor)
        {
            index = GL.GenTexture();
       //     GL.BindTexture(,);
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
