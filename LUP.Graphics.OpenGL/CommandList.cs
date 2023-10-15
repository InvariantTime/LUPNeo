using LUP.Math;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    class CommandList : IGraphicsCommandList
    {
        public IVertexDrawer Drawer { get; }

        public CommandList()
        {
            Drawer = new VertexDrawer();
        }


        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        }


        public void SetView(Vector2 position, Vector2 size)
        {
            GL.Viewport((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
    }
}
