using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public readonly record struct VertexAttribPointer(int Index, int Size, VertexAttribPointerTypes Type, int Stride, int Offset);
}
