using LUP.Graphics.Enums;
using LUP.Rendering.Effects.Generation;

namespace LUP.Rendering.Materials.Sources
{
    class MaterialUniformResolver
    {
        public static ShaderParam Resolve(MaterialParameter parameter, string type)
        {
            return new ShaderParam(type, parameter.Key.Key);
        }
    }
}