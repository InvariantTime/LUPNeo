using LUP.Graphics.Enums;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    public class VertexDrawer : IVertexDrawer//TODO: implementation
    {
        private IEnumerable<VertexAttribPointer>? cached;

        public void PrepareDraw(IEnumerable<VertexAttribPointer> pointers)
        {
            cached = pointers;

            foreach (var pointer in pointers)
            {
                GL.EnableVertexAttribArray(pointer.Index);
                GL.VertexAttribPointer(pointer.Index, pointer.Size, (VertexAttribPointerType)pointer.Type, false, pointer.Stride, pointer.Offset);
            }
        }


        public void Draw(PrimitiveTypes primitive, int first, int count)
        {
            GL.DrawArrays((PrimitiveType)primitive, first, count);
        }

        public void DrawIndiced(PrimitiveTypes primitive, int first, int count)
        {
            GL.DrawElements(PrimitiveType.Triangles, count, DrawElementsType.UnsignedInt, first);
        }

        public void DrawIndicedInstancing()
        {
            throw new NotImplementedException();
        }

        public void DrawInstancing()
        {
            throw new NotImplementedException();
        }

        public void FinishDraw()
        {
            if (cached == null)
                return;

            foreach (var pointer in cached)
                GL.DisableVertexAttribArray(pointer.Index);

            cached = null;
        }
    }
}
