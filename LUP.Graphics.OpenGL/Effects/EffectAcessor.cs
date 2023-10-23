using LUP.Graphics.Effects;
using LUP.Math;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Effects
{
    class EffectAcessor : IEffectAcessor
    {
        private readonly ImmutableDictionary<string, GLUniform> uniforms;

        public EffectAcessor(IEnumerable<GLUniform> uniforms)
        {
            this.uniforms = uniforms.ToImmutableDictionary(x => x.Name);
        }


        public void Set(string name, float value) => TrySet(name, EffectUniformTypes.Float, x => GL.Uniform1(x, value));


        public void Set(string name, int value) => TrySet(name, EffectUniformTypes.Int, x => GL.Uniform1(x, value));


        public void Set(string name, bool value) => TrySet(name, EffectUniformTypes.Bool, x => GL.Uniform1(x, Convert.ToInt32(value)));


        public void Set(string name, double value) => TrySet(name, EffectUniformTypes.Double, x => GL.Uniform1(x, value));


        public void Set(string name, uint value) => TrySet(name, EffectUniformTypes.Uint, x => GL.Uniform1(x, value));


        public void Set(string name, Vec2<float> value) => TrySet(name, EffectUniformTypes.Vec2, x => GL.Uniform2(x, value.X, value.Y));


        public void Set(string name, Vec2<int> value) => TrySet(name, EffectUniformTypes.IVec2, x => GL.Uniform2(x, value.X, value.Y));


        public void Set(string name, Vec2<double> value) => TrySet(name, EffectUniformTypes.DVec2, x => GL.Uniform2(x, value.X, value.Y));


        public void Set(string name, Vec2<uint> value) => TrySet(name, EffectUniformTypes.UVec2, x => GL.Uniform2(x, value.X, value.Y));


        public void Set(string name, Vec3<float> value) => TrySet(name, EffectUniformTypes.Vec3, x => GL.Uniform3(x, value.X, value.Y, value.Z));


        public void Set(string name, Vec3<int> value) => TrySet(name, EffectUniformTypes.IVec3, x => GL.Uniform3(x, value.X, value.Y, value.Z));


        public void Set(string name, Vec3<double> value) => TrySet(name, EffectUniformTypes.DVec3, x => GL.Uniform3(x, value.X, value.Y, value.Z));


        public void Set(string name, Vec3<uint> value) => TrySet(name, EffectUniformTypes.UVec3, x => GL.Uniform3(x, value.X, value.Y, value.Z));


        public void Set(string name, Vec4<float> value) => TrySet(name, EffectUniformTypes.Vec4, x => GL.Uniform4(x, value.X, value.Y, value.Z, value.W));


        public void Set(string name, Vec4<int> value) => TrySet(name, EffectUniformTypes.IVec4, x => GL.Uniform4(x, value.X, value.Y, value.Z, value.W));


        public void Set(string name, Vec4<double> value) => TrySet(name, EffectUniformTypes.DVec4, x => GL.Uniform4(x, value.X, value.Y, value.Z, value.W));


        public void Set(string name, Vec4<uint> value) => TrySet(name, EffectUniformTypes.UVec4, x => GL.Uniform4(x, value.X, value.Y, value.Z, value.W));


        public void Set(string name, Matrix4 value) => TrySet(name, EffectUniformTypes.Mat4, x => GL.UniformMatrix4(x, 1, true, ref value.M11));


        public void Set(string name, Matrix4[] value)
        {
            
        }


        private void TrySet(string name, EffectUniformTypes type, Action<int> gl)
        {
            if (uniforms.ContainsKey(name) == false)
                return;

            var uniform = uniforms[name];

            if (uniform.Type != type)
                return;

            gl.Invoke(uniform.Index);
        }
    }

    readonly struct GLUniform : IUniformData
    {
        public string Name { get; init; }

        public int Index { get; init; }

        public EffectUniformTypes Type { get; init; }
    }
}
