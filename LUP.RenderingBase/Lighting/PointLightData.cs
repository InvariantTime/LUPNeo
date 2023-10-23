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
    public struct PointLightData
    {
        [FieldOffset(0)]
        public Vector3 Position;

        [FieldOffset(12)]
        public float InvSquareRadius;

        [FieldOffset(16)]
        public Vector3 Color;
    }
}
