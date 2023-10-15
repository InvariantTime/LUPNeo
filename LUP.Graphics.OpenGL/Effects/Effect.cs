using LUP.Math;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Effects
{
    class Effect : DisposableObject, IEffect
    {
        private readonly GLProgram program;
        private readonly Dictionary<string, int> locations;

        public Effect(EffectDescriptor descriptor)
        {
            program = new GLProgram(descriptor.Datas);
            locations = new Dictionary<string, int>();
        }


        public void Bind()
        {
            program.Bind();
        }


        public void SetUniform(string name, uint value)
        {
            int loc = GetLocation(name);
            GL.Uniform1(loc, value);
        }


        public void SetUniform(string name, int value)
        {

            int loc = GetLocation(name);
            GL.Uniform1(loc, value);
        }


        public void SetUniform(string name, float value)
        {

            int loc = GetLocation(name);
            GL.Uniform1(loc, value);
        }


        public void SetUniform(string name, Vector2 vector)
        {
            int loc = GetLocation(name);
            GL.Uniform2(loc, vector.X, vector.Y);
        }


        public void SetUniform(string name, Vector3 vector)
        {
            int loc = GetLocation(name);
            GL.Uniform3(loc, vector.X, vector.Y, vector.Z);
        }


        public void SetUniform(string name, Vector4 vector)
        {
            int loc = GetLocation(name);
            GL.Uniform4(loc, vector.X, vector.Y, vector.Z, vector.W);
        }


        public void SetUniform(string name, Matrix4 matrix)
        {
            int loc = GetLocation(name);
            GL.UniformMatrix4(loc, 1, true, ref matrix.M11);
        }


        public void Unbind()
        {
            GL.UseProgram(0);
        }


        private int GetLocation(string name) 
        {
            bool result = locations.TryGetValue(name, out int location);
        
            if (result == false)
            {
                location = GL.GetUniformLocation(program.Index, name);
                locations.Add(name, location);
            }

            return location;
        }
    }
}
