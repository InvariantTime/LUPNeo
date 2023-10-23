using LUP.Math;
using LUP.Rendering.RenderTargets;
using LUP.SceneGraph;

namespace LUP.Rendering.Components
{
    public class CameraComponent : Component, ICamera
    {
        public Perspective3D Perspective { get; }

        public CameraComponent()
        {
            Perspective = new();
        }


        public Matrix4 GetProjection()
        {
            return Perspective.GetMatrix();
        }


        public Matrix4 GetView()
        {
            var direction = Quaternion.RotateVector(Vector3.Forward, Transform.Rotation);
            var up = Quaternion.RotateVector(Vector3.Up, Transform.Rotation);

            var target = Transform.Position + direction;

            return LMath.LookAt(Transform.Position, target, up);
        }
    }
}
