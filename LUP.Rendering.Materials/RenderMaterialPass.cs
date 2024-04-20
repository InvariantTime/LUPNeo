using LUP.Graphics;
using LUP.Rendering.Effects;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Materials
{
    public class RenderMaterialPass
    {
        private readonly ImmutableDictionary<MaterialKey, MaterialParameter> parameters;
        private readonly RenderEffect effect;
        //private readonly MaterialParameterProfiler profiler;

        public RenderMaterialPass(RenderEffect effect, IEnumerable<MaterialParameter> parameters)
        {
            this.effect = effect;
            this.parameters = parameters.ToImmutableDictionary(x => x.Key);
        }


        public void SetParameter<T>(MaterialKey key, T parameter) where T : struct
        {
            bool result = parameters.TryGetValue(key, out var value);

            if (result == false)
                return;

            if (value is not MaterialParameter<T> generic)
                throw new Exception();


        }


        public void SetParameter(MaterialKey key, GraphicsResource texture)
        {
            bool result = parameters.TryGetValue(key, out var value);

            if (result == false)
                return;

            if (value is not MaterialTextureParamter tex)
                throw new Exception();


        }
    }
}
