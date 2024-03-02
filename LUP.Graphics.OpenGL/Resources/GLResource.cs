using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    abstract class GLResource : IDisposable
    {
        public const int InvalidIndex = -1;

        public abstract void Dispose();

        public abstract void Bind();

        public abstract void Unbind();

        public abstract int GetIndex();
    }
}
