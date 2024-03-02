using LUP.Math;
using LUP.Math.Shaders;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    static class ShaderAccessors
    {
        public static void SetFloat(int location, float value)
        {
            GL.Uniform1(location, value);
        }


        public static void SetInt(int location, int value)
        {
            GL.Uniform1(location, value);
        }


        public static void SetDouble(int location, double value)
        {
            GL.Uniform1(location, value);
        }


        public static void SetUint(int location, uint value)
        {
            GL.Uniform1(location, value);
        }


        public static void SetVec2(int location, Vector2 value)
        {
            GL.Uniform2(location, value.X, value.Y);
        }


        public static void SetIVec2(int location, Vec2<int> value)
        {
            GL.Uniform2(location, value.X, value.Y);
        }


        public static void SetDVec2(int location, Vec2<double> value)
        {
            GL.Uniform2(location, value.X, value.Y);
        }


        public static void SetUVec2(int location, Vec2<uint> value)
        {
            GL.Uniform2(location, value.X, value.Y);
        }


        public static void SetVec3(int location, Vector3 value)
        {
            GL.Uniform3(location, value.X, value.Y, value.Z);
        }


        public static void SetIVec3(int location, Vec3<int> value)
        {
            GL.Uniform3(location, value.X, value.Y, value.Z);
        }


        public static void SetDVec3(int location, Vec3<double> value)
        {
            GL.Uniform3(location, value.X, value.Y, value.Z);
        }


        public static void SetUVec3(int location, Vec3<uint> value)
        {
            GL.Uniform3(location, value.X, value.Y, value.Z);
        }


        public static void SetVec4(int location, Vector4 value)
        {
            GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }


        public static void SetIVec4(int location, Vec4<int> value)
        {
            GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }


        public static void SetDVec4(int location, Vec4<double> value)
        {
            GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }


        public static void SetUVec4(int location, Vec4<uint> value)
        {
            GL.Uniform4(location, value.X, value.Y, value.Z, value.W);
        }


        public static void SetMat4(int location, Matrix4 value)
        {
          //  GL.UniformMatrix4(location, false, );
        }


    }
}
