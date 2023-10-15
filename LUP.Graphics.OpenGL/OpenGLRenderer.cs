using LUP.Client;
using LUP.Logging;
using LUP.Math;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LUP.Graphics.OpenGL//TODO: rewrite
{
    unsafe class OpenGLRenderer : IWindowRenderer
    {
        private readonly ILogger<OpenGLRenderer> logger;

        public GLFWBindingsContext? Binding { get; private set; }

        public OpenGLRenderer(ILogger<OpenGLRenderer> logger)
        {
            this.logger = logger;
        }


        public void Init(IntPtr window, int width, int height)
        {
            try
            {
                var win = (Window*)window.ToPointer();
                GLFW.MakeContextCurrent(win);

                Binding = new GLFWBindingsContext();
                GL.LoadBindings(Binding);
                GL.Viewport(0, 0, width, height);
            }
            catch (Exception ex)
            {
                logger.Error("Unable to initialize opengl context", ex);
            }
        }


        public void Render()
        {
        }


        public void Resize(Vector2 size)
        {
            GL.Viewport(0, 0, (int)size.X, (int)size.Y);
        }
    }
}
