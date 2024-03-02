using LUP.Graphics.Commanding;
using LUP.Graphics.OpenGL.Resources;

namespace LUP.Graphics.OpenGL.Commanding
{
    class GraphicsCommandList : IGraphicsCommandList
    {
        public ShaderCommands ShaderCommands { get; }

        public DrawingCommands DrawingCommands { get; }

        public TexturingCommands TexturingCommands { get; }

        public BufferCommands BufferCommands { get; }

        public StateCommands StateCommands { get; }

        public IGraphicsCommandProvider? PlatformCommands { get; }

        public GraphicsCommandList(OpenGLFactory resources)
        {
            ShaderCommands = new GLShaderCommands(resources);
            TexturingCommands = new GLTexturingCommands(resources);
            StateCommands = new GLStateCommands(resources);
            BufferCommands = new GLBufferCommands(resources);

            DrawingCommands = new GLDrawingCommands();
            PlatformCommands = new OpenGLCommands();
        }
    }
}
