using LUP.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public readonly struct RawMesh
    {
        public required RawVertices Vertices { get; init; }

        public RawBuffer? Indices { get; init; }

        public int Count { get; init; }
    }

    public readonly struct RawVertices
    {
        public required RawBuffer Buffer { get; init; }

        public required VertexDescription Description { get; init; }
    }
}
