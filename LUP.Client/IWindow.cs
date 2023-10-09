using LUP.Math;

namespace LUP.Client
{
    public interface IWindow
    {
        Vector2 Size { get; set; }

        IWindowRenderer Renderer { get; }

        void Update();

        void SwapBuffers();
    }

    public interface IDesktopWindow : IWindow
    {
        string Title { get; set; }

        bool Visible { get; set; }

        bool Fullscreen { get; set; }
    }
}
