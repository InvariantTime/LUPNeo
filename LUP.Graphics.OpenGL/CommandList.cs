using LUP.Graphics.Enums;
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


        public void SetTextureBinding(TextureBindings binding)
        {
            GL.ActiveTexture(OpenGLConverter.Convert(binding));
        }


        public void SetState(GraphicsState state)
        {
            SetDepth(state.Depth);
            SetStencil(state.Stencil);
            SetBlend(state.Blend);
        }


        private static void SetDepth(GraphicsDepth depth)
        {
            if (depth.Enable == true)
            {
                GL.Enable(EnableCap.DepthTest);
            }
            else
            {
                GL.Disable(EnableCap.DepthTest);
                return;
            }

            GL.DepthMask(depth.WriteEnable);
            GL.DepthFunc(OpenGLConverter.Convert(depth.Function));
        }


        private static void SetStencil(GraphicsStencil depth)
        {

        }


        private static void SetBlend(GraphicsBlend blend)
        {

        }
    }
}
