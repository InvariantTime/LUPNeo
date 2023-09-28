using LUP.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
