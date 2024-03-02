using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public readonly struct DataBufferDescriptor
    {
        public BufferData Data { get; init; }

        public BufferUsages Usage { get; init; }

        public BufferTypes Type { get; init; }
    }
}