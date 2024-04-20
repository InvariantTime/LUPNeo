using LUP.Math;

namespace LUP.Rendering.Base
{
    public interface ICamera
    {
        Matrix4 GetView();

        Matrix4 GetProjection();
    }
}