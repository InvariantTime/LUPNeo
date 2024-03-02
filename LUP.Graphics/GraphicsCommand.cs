using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public readonly struct GraphicsCommand
    {
        public uint Type { get; init; }

        public object? Data { get; init; }

        public GraphicsCommand(uint type, object? data = null) 
        {
            Type = type;
            Data = data;
        }
    }
}
