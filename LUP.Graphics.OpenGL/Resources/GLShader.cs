using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLShader : GLResource
    {
        private readonly ImmutableDictionary<string, Uniform> uniforms;
        private readonly int index;

        public GLShader(IDictionary<string, Uniform> uniforms, int index)
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

        
        public void SetUniform(string name, ValueType value)
        {
            bool result = uniforms.TryGetValue(name, out var uniform);

            if (result == false)
                throw new Exception($"Uknown uniform name: {name}");

            uniform.Accessor.Invoke(uniform.Location, value);
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

    public readonly struct Uniform
    {
        public int Location { get; init; }

        public ActiveUniformType Type { get; init; }

        public Action<int, ValueType> Accessor { get; init; }
    }
}
