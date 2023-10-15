using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input.GLFWInput
{
    unsafe sealed class GLFWKeyboard : IKeyboard
    {
        private readonly Window* window;

        public event EventHandler<KeyboardEventArgs>? KeyPressed;

        public event EventHandler<KeyboardEventArgs>? KeyReleased;

        public GLFWKeyboard(Window* window)
        {
            this.window = window;
        }


        public bool IsKeyPressed(KeyboardKeys key)
        {
            return GLFW.GetKey(window, (Keys)key) == InputAction.Press;
        }


        public void KeyboardClick(KeyboardKeys key, InputAction action)
        {
            var args = new KeyboardEventArgs
            {
                Key = key,
            };

            if (action == InputAction.Press)
                KeyPressed?.Invoke(this, args);
            else if (action == InputAction.Release)
                KeyReleased?.Invoke(this, args);
        }
    }
}
