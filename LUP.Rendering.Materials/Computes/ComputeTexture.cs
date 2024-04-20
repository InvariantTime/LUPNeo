using LUP.Graphics;
using LUP.Rendering.Materials.Sources;

namespace LUP.Rendering.Materials.Computes
{
    public class ComputeTexture : IComputeColor
    {
        private const string uniformType = "sampler2D";

        public GraphicsResource Texture { get; }

        public string Generate(MaterialContext context, MaterialKey key, MaterialSource source)
        {
            var param = new MaterialTextureParamter(Texture, key);
            source.AddUniform(param, uniformType);
            // source.AddDefine("USE_UV");

            context.AddParameter(param);

            return $"return texture({key.Key}, _uv.xy);";
        }
    }
}
