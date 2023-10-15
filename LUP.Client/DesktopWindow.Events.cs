using LUP.Client.Input;
using LUP.Math;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    unsafe sealed partial class DesktopWindow : DisposableObject, IDesktopWindow
    {
        private GLFWCallbacks.FramebufferSizeCallback? frameBufferSizeCallback;
        private GLFWCallbacks.WindowCloseCallback? closedCallback;
        private GLFWCallbacks.WindowSizeCallback? sizeCallback;

        public event Action<Vector2>? FrameBufferResized;

        public event Action<Vector2>? WindowResized;

        public event Action? WindowClosed;

        private void InitCallbacks(Window* window)
        {
            input.InitCallbacks();

            frameBufferSizeCallback = OnResizeFrameBuffer;
            sizeCallback = OnResizeWindow;
            closedCallback = OnWindowClosed;

            GLFW.SetFramebufferSizeCallback(window, frameBufferSizeCallback);
            GLFW.SetWindowSizeCallback(window, sizeCallback);
            GLFW.SetWindowCloseCallback(window, closedCallback);
        }


        private void OnResizeWindow(Window* window, int w, int h)
        {
            WindowResized?.Invoke(new Vector2(w, h));
        }


        private void OnResizeFrameBuffer(Window* window, int w, int h)
        {
            Vector2 size = new(w, h);

            Renderer.Resize(size);
            FrameBufferResized?.Invoke(size);

        }


        private void OnWindowClosed(Window* window)
        {
            WindowClosed?.Invoke();
        }
    }
}
