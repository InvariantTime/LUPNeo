using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Rendering.Meshing;

namespace LUP.Rendering
{
    public readonly struct MeshDraw
    {
        public required VerticesBinding Vertices { get; init; }

        public IndicedBinding? Indices { get; init; }

        public PrimitiveTypes Primitive { get; init; }

        public int Count { get; init; }

        public int StartLocation { get; init; }

        public bool IsIndiced => Indices != null;

        public MeshDraw()
        {
            Primitive = PrimitiveTypes.Triangles;
        }
    }
}
