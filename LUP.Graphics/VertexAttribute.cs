using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public readonly record struct VertexAttribute(int Index, int Size, VertexAttribPointerTypes Type, int Stride, int Offset);
}
