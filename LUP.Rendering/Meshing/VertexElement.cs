using LUP.Graphics.Enums;

namespace LUP.Rendering.Meshing
{
    public readonly struct VertexElement
    {
        public VertexKey Key { get; init; }

        public int Offset { get; init; }

        public int Stride { get; init; }

        public VertexAttribPointerTypes Format { get; init; }

        public VertexElement(VertexKey key, VertexAttribPointerTypes format, int offset = 0, int stride = 0)
        {
            Key = key;
            Format = format;
            Offset = offset;
            Stride = stride;
        }
    }
}
