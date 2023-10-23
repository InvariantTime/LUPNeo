using LUP.Graphics.Effects;
using LUP.Math;
using System.Collections.Immutable;

namespace LUP.Graphics
{
    public interface IEffect : IDisposable
    {
        IEffectAcessor Uniforms { get; }

        void Bind();

        void Unbind();
    }
}
