using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input
{
    public class MouseEventArgs : EventArgs
    {
        public MouseButtons Button { get; init; }
    }

    public class CursorArgs : EventArgs
    {
        public Vector2 Position { get; init; }
    }
}
