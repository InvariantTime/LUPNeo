using LUP.Client.Input;
using LUP.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LUP.Client
{
    unsafe sealed class DesktopWindow : DisposableObject, IDesktopWindow, IInputHandler
    {
        private readonly Window* window;

        public string Title
        {
            get => "";

            set { }
        }


        public bool Visible
        {
            get => true;

            set
            {
                if (value == true)
                    GLFW.ShowWindow(window);
                else
                    GLFW.HideWindow(window);
            }
        }

        public bool Fullscreen//TODO: window fullscreen
        {
            get => false;

            set
            {

            }
        }

        public Vector2 Size
        {
            get
            {
                GLFW.GetWindowSize(window, out int w, out int h);
                return new Vector2(w, h);
            }

            set
            {
                GLFW.SetWindowSize(window, (int)value.X, (int)value.Y);
            }
        }

        public IWindowRenderer Renderer { get; }

        public DesktopWindow(IOption<WindowConfig> option, IWindowRenderer renderer)
        {
            GLFW.Init();

            var op = option.Accessor;
            window = GLFW.CreateWindow((int)op.Size.X, (int)op.Size.Y, op.Title, null, null);

            if (op.Visible == true)
                GLFW.ShowWindow(window);

            Renderer = renderer ?? new DefaultRenderer();
            Renderer.Init(new nint(window));

            GLFW.SetWindowSizeCallback(window, (o, w, h) => Renderer.Resize(new Vector2(w, h)));
        }


        public void Update()
        {
            GLFW.WaitEvents();
        }


        public void SwapBuffers()
        {
            GLFW.SwapBuffers(window);
        }


        protected override void OnUnmanagedDisposed()
        {
            GLFW.DestroyWindow(window);
        }
    }
}
