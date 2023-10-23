using LUP.Rendering.ShaderLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Materials
{
    public sealed class RenderMaterialBuilder
    {
        private readonly ShaderCompiler compiler;

        public RenderMaterialBuilder(ShaderCompiler compiler)
        {
            this.compiler = compiler;
        }


        public RenderMaterial Build()
        {
            throw new NotImplementedException();
        }
    }
}
