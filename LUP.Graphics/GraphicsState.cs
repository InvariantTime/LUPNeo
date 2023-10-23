using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    //TODO Graphics state
    public class GraphicsState
    {
        public GraphicsDepth Depth { get; set; } = new GraphicsDepth();

        public GraphicsStencil Stencil { get; set; } = new GraphicsStencil();

        public GraphicsBlend Blend { get; set; } = new GraphicsBlend();
    }
}
