using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Graphics.OpenGL.Effects;
using LUP.Graphics.Rendertargets;
using LUP.Math;

namespace OpenGLExample
{
    public class ScreenDrawer
    {
        private static readonly VertexAttribPointer[] pointers =
{
            new VertexAttribPointer(0, 2, VertexAttribPointerTypes.Float, 16, 0),
            new VertexAttribPointer(1, 2, VertexAttribPointerTypes.Float, 16, 8)
        };

        private static readonly FrameBufferDescriptor fboDescriptor =
            FrameBufferDescriptor.New(new Vector2(800, 600), null,
                new FBOTextureDescriptor[]
                {
                    new FBOTextureDescriptor(TextureDimensionTypes.Texture2D,
                        new TextureFormat(PixelTypes.UnsignedByte, PixelFormats.Rgb, PixelCodes.Rgb))
                });

        private readonly IGraphicsDevice device;
        private readonly IDataBuffer vbo;

        public IFrameBuffer FBO { get; }

        public ScreenDrawer(IGraphicsDevice device)
        {
            this.device = device;

            vbo = device.DataBuffers.Invoke(BufferTypes.Array);
            vbo.SetData(new float[]
            {
                -1, +1, 0, 1,
                -1, -1, 0, 0,
                +1, -1, 1, 0,
                +1, -1, 1, 0,
                +1, +1, 1, 1,
                -1, +1, 0, 1

            }, sizeof(float) * 24, BufferUsages.StaticDraw);

            FBO = device.FBOs.Invoke(fboDescriptor);
        }


        public void Draw()
        {
            var commands = device.GetCommandList();

            FBO.Colors[0]?.Texture.Bind();
            Shaders.ScreenShader.Bind();
            vbo.Bind();
            commands.Clear();
            commands.Drawer.PrepareDraw(pointers);

            commands.Drawer.Draw(PrimitiveTypes.Triangles, 0, 6);

            GLProgram.Unbind();
            commands.Drawer.FinishDraw();
            FBO.Colors[0]?.Texture.Unbind();
            vbo.Unbind();
        }
    }
}
