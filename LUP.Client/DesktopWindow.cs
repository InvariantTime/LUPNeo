using LUP.Client.Input;
using LUP.Client.Input.GLFWInput;
using LUP.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LUP.Client
{
    //TODO: input
    unsafe sealed partial class DesktopWindow : DisposableObject, IDesktopWindow
    {
        private readonly Window* window;
        private readonly GLFWInput input;

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

        public DesktopWindowStates States { get; set; }

        public IInputHandler Input => input;

        public DesktopWindow(IOption<WindowConfig> option, IWindowRenderer renderer)
        {
            GLFW.Init();

            var op = option.Accessor;
            window = GLFW.CreateWindow((int)op.Size.X, (int)op.Size.Y, op.Title, null, null);

            if (op.Visible == true)
                GLFW.ShowWindow(window);

            input = new GLFWInput(window);

            Renderer = renderer ?? new DefaultRenderer();
            Renderer.Init(new nint(window), (int)op.Size.X, (int)op.Size.Y);

            InitCallbacks(window);
        }


        public void Update()
        {
            GLFW.SwapBuffers(window);
            GLFW.PollEvents();
        }


        protected override void OnManagedDisposed()
        {
            GLFW.DestroyWindow(window);
        }


        private void OnStateChange()
        {

        }
    }
}
