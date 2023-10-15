using LUP.Math;

namespace LUP.Graphics
{
    public interface IEffect : IDisposable
    {
        void Bind();

        void Unbind();

        void SetUniform(string name, uint value);

        void SetUniform(string name, int value);

        void SetUniform(string name, float value);

        void SetUniform(string name, Vector2 vector);

        void SetUniform(string name, Vector3 vector);

        void SetUniform(string name, Vector4 vector);

        void SetUniform(string name, Matrix4 matrix);
    }
}
