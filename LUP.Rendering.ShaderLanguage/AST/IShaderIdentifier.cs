using LUP.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST
{
    public interface IShaderIdentifier : IASTExpression
    {
        string Name { get; }
    }
}
