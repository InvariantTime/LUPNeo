using OpenTK.Graphics.OpenGL;
using System.Collections.Immutable;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLShader : GLResource
    {
        private readonly ImmutableDictionary<string, int> uniforms;
        private readonly int index;

        public GLShader(IDictionary<string, int> uniforms, int index)
        {
            this.index = index;
            this.uniforms = uniforms.ToImmutableDictionary();
        }


        public override void Bind()
        {
            GL.UseProgram(index);
        }


        public override void Unbind()
        {
            GL.UseProgram(0);
        }


        public override void Dispose()
        {
            GL.DeleteProgram(index);
        }

        
        public void SetUniform(ShaderUniform uniform, ValueType value)
        {
            bool result = uniforms.TryGetValue(uniform.Name, out int index);

            if (result == false)
                throw new Exception($"Uknown uniform name: {uniform.Name}");

            ShaderUniformDelegateInstance.Instance.Invoke(index, uniform.Type, value);
        }


        public void BindConstantBuffer(int binding, string name)
        {
            int buffer = GL.GetUniformBlockIndex(index, name);
            GL.UniformBlockBinding(index, buffer, binding);
        }


        public override int GetIndex()
        {
            return index;
        }
    }
}
