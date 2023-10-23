using LUP.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Lighting
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct DirectionLightData
    {
        [FieldOffset(0)]
        public Vector3 Direction;

        [FieldOffset(16)]
        public Vector3 Color;
    }
}
