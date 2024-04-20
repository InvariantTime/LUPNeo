using LUP.Math;
using System.Runtime.InteropServices;

namespace LUP.Rendering.Data
{
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct SceneRenderData
    {
        public const int Size = 244;

        [field: FieldOffset(0)]
        public Matrix4 Projection { get; set; }

        [field: FieldOffset(64)]
        public Matrix4 View { get; set; }

        [field: FieldOffset(128)]
        public Matrix4 ViewWithoutPosition { get; set; }

        [field: FieldOffset(192)]
        public float Time { get; set; }

        [field: FieldOffset(208)]
        public Vector3 ViewPosition { get; set; }

        [field: FieldOffset(224)]
        public Vector2 ViewportSize { get; set; }

        [field: FieldOffset(232)]
        public Vector2 ScreenSize { get; set; }

        [field: FieldOffset(236)]
        public float ZFar { get; set; }

        [field: FieldOffset(240)]
        public float ZNear { get; set; }
    }
}
