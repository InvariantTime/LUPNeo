using LUP.Client.Input;
using LUP.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LUP.Client.Input.GLFWInput
{
    sealed unsafe class GLFWInput : DisposableObject, IInputHandler
    {
        private GLFWCallbacks.MouseButtonCallback? mouseButtonCallback;
        private GLFWCallbacks.CursorPosCallback? cursorPosCallback;
        private GLFWCallbacks.KeyCallback? keyCallback;

        private readonly GLFWMouse mouse;
        private readonly GLFWKeyboard keyboard;
        private readonly Window* window;

        public IMouse Mouse => mouse;

        public IKeyboard Keyboard => keyboard;

        public GLFWInput(Window* window)
        {
            this.window = window;

            mouse = new GLFWMouse(window);
            keyboard = new GLFWKeyboard(window);
        }


        public void InitCallbacks()
        {
            mouseButtonCallback = OnMouseClick;
            keyCallback = OnKeyClick;
            cursorPosCallback = OnCursorMoved;

            GLFW.SetMouseButtonCallback(window, mouseButtonCallback);
            GLFW.SetKeyCallback(window, keyCallback);
            GLFW.SetCursorPosCallback(window, cursorPosCallback);
        }


        public void Update()
        {
        }


        private void OnMouseClick(Window* window, MouseButton button, InputAction action, OpenTK.Windowing.GraphicsLibraryFramework.KeyModifiers mods)
        {
            mouse.MouseClick((MouseButtons)button, action);
        }


        private void OnKeyClick(Window* window, Keys key, int scanCode, InputAction action, OpenTK.Windowing.GraphicsLibraryFramework.KeyModifiers mods)
        {
            keyboard.KeyboardClick((KeyboardKeys)key, action);
        }


        private void OnCursorMoved(Window* window, double x, double y)
        {
            mouse.MoveMouse(x, y);
        }
    }
}
