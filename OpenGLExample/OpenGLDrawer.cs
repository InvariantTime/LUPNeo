using LUP;
using LUP.Graphics;
using LUP.Graphics.Enums;

namespace OpenGLExample
{
    public class OpenGLDrawer : IApplicationStage
    {
        private static readonly VertexAttribPointer[] pointers =
        {
            new VertexAttribPointer(0, 3, VertexAttribPointerTypes.Float, 0, 0)
        };

        private static readonly float[] triangle =
        {
            1, 1, 0,
            1, 0, 0,
            0, 0, 0
        };

        private readonly IGraphicsDevice device;
        private readonly ScreenDrawer screen;
        private readonly IDataBuffer vbo;

        public OpenGLDrawer(IGraphicsDevice device)
        {
            this.device = device;

            vbo = device.DataBuffers.Invoke(BufferTypes.Array);
            vbo.SetData(triangle, sizeof(float) * triangle.Length, BufferUsages.StaticDraw);

            screen = new ScreenDrawer(device);
        }

        public void Handle(LoopContext context)
        {
            var commands = device.GetCommandList();

            screen.FBO.Bind();
            vbo.Bind();
            commands.Drawer.PrepareDraw(pointers);
            commands.Drawer.Draw(PrimitiveTypes.Triangles, 0, 3);

            vbo.Unbind();
            screen.FBO.Unbind();
            commands.Drawer.FinishDraw();

            screen.Draw();
        }
    }
}
