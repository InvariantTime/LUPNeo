using LUP.Math;
using LUP.Rendering.Materials.Sources;

namespace LUP.Rendering.Materials.Computes
{
    public class ComputeColor : IComputeColor
    {
        private const string uniformType = "vec4";

        public Vector4 Color { get; set; }

        public string Generate(MaterialContext context, MaterialKey key, MaterialSource source)
        {
            var param = new MaterialParameter<Vector4>(Color, key);
            context.AddParameter(param);

            source.AddUniform(param, uniformType);

            return $"return {key.Key}";
        }
    }
}
