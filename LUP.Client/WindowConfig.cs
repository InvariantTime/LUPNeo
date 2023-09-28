using LUP.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    public sealed class WindowConfig
    {
        public bool IsFullscreen { get; set; }

        public bool Visible { get; set; } = true;

        public bool Resizable { get; set; } = true;

        public string Title { get; set; } = string.Empty;

        public Vector2 Size { get; set; } = new Vector2(800, 600);

        public WindowFlags Flags { get; set; }

        public IWindowRenderer? Renderer { get; set; }
    }
}
