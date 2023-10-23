using LUP.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public class VerticesBinding
    {
        public IDataBuffer Buffer { get; }

        public VertexDescription Description { get; }

        public VerticesBinding(IDataBuffer buffer, VertexDescription description)
        {
            Buffer = buffer;
            Description = description;
        }


        public void Prepare(IVertexDrawer drawer)
        {
            Buffer.Bind();
            drawer.PrepareDraw(Description.Pointers);
        }


        public void Unbind()
        {
            Buffer.Unbind();
        }
    }
}
