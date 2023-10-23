using LUP.Graphics.Effects;
using LUP.Graphics.OpenGL.Effects;

namespace LUP.Graphics.OpenGL.Factories
{
    static class GLEffectFactory
    {
        public static IEffect Build(EffectDescriptor descriptor)
        {
            return new Effect(descriptor);
        }
    }
}
