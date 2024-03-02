using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public readonly struct ShaderConstantBinding
    {
        public GraphicsResource Shader { get; init; }

        public int Index { get; init; }

        public string BindingName { get; init; }
    }
}
