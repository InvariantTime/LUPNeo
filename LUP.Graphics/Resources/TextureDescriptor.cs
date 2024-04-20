using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public readonly struct TextureDescriptor
    {
        public int Width { get; init; }

        public int Height { get; init; }

        public int Size { get; init; }

        public IntPtr Data { get; init; }

        public TextureTypes Type { get; init; }
    }
}
