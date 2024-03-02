using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language
{
    public readonly struct ShaderParamValue
    {
        public string Name { get; }

        public ShaderClass? Param { get; }
    }
}
