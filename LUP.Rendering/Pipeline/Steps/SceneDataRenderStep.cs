using LUP.Math;
using System.Runtime.InteropServices;

namespace LUP.Rendering.Pipeline.Steps
{
    public class SceneDataRenderStep : RootRenderStep
    {
        //TODO: time
        private float time;

        public override void Prepare(RenderScene scene)
        {
            var buffer = Context.Device.GetConstantBuffer(DefaultConstantBuffers.SceneData);

            var data = new SceneData
            {
                Projection = scene.View.GetProjection(),
                View = scene.View.GetView(),
                ViewPosition = new Vector3(),
                Time = time,
                ViewportSize = new Vector2(800, 600),
                ViewWithoutPosition = scene.View.GetView()
            };

            buffer.SetData(data, 0);
            time += 0.005f;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 240)]
    public struct SceneData
    {
        [FieldOffset(0)]
        public Matrix4 Projection;

        [FieldOffset(64)]
        public Matrix4 View;

        [FieldOffset(128)]
        public Matrix4 ViewWithoutPosition;

        [FieldOffset(192)]
        public Vector3 ViewPosition;

        [FieldOffset(208)]
        public Vector2 ViewportSize;

        [FieldOffset(216)]
        public float Time;

        [FieldOffset(224)]
        public Vector3 Ambient;
    }
}
