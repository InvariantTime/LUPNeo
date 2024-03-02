using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    public interface IGLBuffer
    {
        void Update(BufferData data, int offset);
    }
}
