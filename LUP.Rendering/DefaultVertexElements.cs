using LUP.Graphics.Enums;
using LUP.Rendering.Meshing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public static class DefaultVertexElements
    {
        public static readonly VertexKey Position = VertexKey.New("position_in", index: 0, size: 3);

        public static readonly VertexKey UV = VertexKey.New("uv_in", index: 1, size: 2);

        public static readonly VertexKey Normal = VertexKey.New("normal_in", index: 2, size: 3);
    }
}
