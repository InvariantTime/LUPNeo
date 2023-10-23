using LUP.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LUP.Client.Input.GLFWInput
{
    //TODO: cursor image
    unsafe sealed class GLFWMouse : IMouse
    {
        private readonly Window* window;
        private readonly GLFWCursor cursor;

        public event EventHandler<MouseEventArgs>? ButtonDown;

        public event EventHandler<MouseEventArgs>? ButtonRelease;

        public event EventHandler<CursorArgs>? MouseMoved;

        public ICursor Cursor => cursor;

        public GLFWMouse(Window* window)
        {
            this.window = window;

            cursor = new(window);
        }


        public Vector2 GetPosition()
        {
            GLFW.GetCursorPos(window, out var x, out var y);
            return new Vector2((float)x, (float)y);
        }


        public void SetPosition(Vector2 position)
        {
            GLFW.SetCursorPos(window, position.X, position.Y);
        }


        public bool IsButtonPressed(MouseButtons button)
        {
            return GLFW.GetMouseButton(window, (MouseButton)button) == InputAction.Press;
        }


        public void MouseClick(MouseButtons button, InputAction action)
        {
            var args = new MouseEventArgs
            {
                Button = button
            };

            if (action == InputAction.Press)
                ButtonDown?.Invoke(this, args);
            else if (action == InputAction.Release)
                ButtonDown?.Invoke(this, args);
        }


        public void MoveMouse(double x, double y)
        {
            var args = new CursorArgs
            {
                Position = new Vector2((float)x, (float)y)
            };

            MouseMoved?.Invoke(this, args);
        }
    }


    unsafe sealed class GLFWCursor : ICursor
    {
        private readonly Window* window;

        public CursorStates State
        {
            get => GLFW.GetInputMode(window, CursorStateAttribute.Cursor).Convert();
            
            set => GLFW.SetInputMode(window, CursorStateAttribute.Cursor, value.Convert());
        }

        public GLFWCursor(Window* window)
        {
            this.window = window;
        }
    }

    static class CursorConvertExtension
    {
        public static CursorStates Convert(this CursorModeValue cursor)
        {
            return cursor switch
            {
                CursorModeValue.CursorDisabled => CursorStates.Disable,

                CursorModeValue.CursorHidden => CursorStates.Hide,

                CursorModeValue.CursorNormal => CursorStates.Enable,

                _ => throw new NotSupportedException()
            };
        }

        public static CursorModeValue Convert(this CursorStates cursor)
        {
            return cursor switch
            {
                CursorStates.Disable => CursorModeValue.CursorDisabled,

                CursorStates.Hide => CursorModeValue.CursorHidden,

                CursorStates.Enable => CursorModeValue.CursorNormal,

                _ => throw new NotSupportedException()
            };
        }
    }
}
