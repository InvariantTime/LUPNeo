using LUP.Math;

namespace LUP.Client
{
    public interface IWindow
    {
        Vector2 Size { get; set; }

        IWindowRenderer Renderer { get; }

        void Update();
    }

    public interface IDesktopWindow : IWindow
    {
        bool Visible { get; set; }

        DesktopWindowStates States { get; set; }
    }
}
