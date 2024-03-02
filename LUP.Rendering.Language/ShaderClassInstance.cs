using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language
{
    public readonly struct ShaderClassInstance
    {
        public ShaderClass Class { get; }

        public IEnumerable<ShaderParamValue> ParamValues { get; }

        public ShaderClassInstance(ShaderClass @class, IEnumerable<ShaderParamValue> values)
        {
            Class = @class;
            ParamValues = values.ToImmutableArray();
        }
    }
}
