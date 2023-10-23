using LUP.Graphics.Effects;
using LUP.Math;
using OpenTK.Graphics.OpenGL;
using System.Collections.Immutable;

namespace LUP.Graphics.OpenGL.Effects
{
    class Effect : DisposableObject, IEffect
    {
        private readonly GLProgram program;
        private readonly IEffectAcessor uniforms;

        public IEffectAcessor Uniforms => uniforms;

        public Effect(EffectDescriptor descriptor)
        {
            program = new GLProgram(descriptor.Datas);
            uniforms = new EffectAcessor(EffectUtils.GenerateUniforms(program));
        }


        public void Bind()
        {
            program.Bind();
        }


        public void Unbind()
        {
            GL.UseProgram(0);
        }


        protected override void OnUnmanagedDisposed()
        {
            program.Dispose();
        }
    }
}
