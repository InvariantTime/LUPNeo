using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public interface IVertexDrawer//TODO: instancing
    {
        void PrepareDraw(IEnumerable<VertexAttribPointer> pointers);

        void Draw(PrimitiveTypes primitive, int first, int count);

        void DrawIndiced(PrimitiveTypes primitive, int first, int count);

        void DrawInstancing();

        void DrawIndicedInstancing();

        void FinishDraw();
    }
}
