using LUP.Math;
using System.Runtime.InteropServices;

namespace LUP.Rendering.Lighting
{
    [StructLayout(LayoutKind.Explicit, Size = 48)]
    public struct SpotLightData
    {
        [FieldOffset(0)]
        public Vector3 Position;

        [FieldOffset(12)]
        public float InvSquareRadius;

        [FieldOffset(16)]
        public Vector3 Direction;

        [FieldOffset(32)]
        public Vector3 Color;
    }
}
