using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST.Handlers
{
    public class ShaderHandler
    {
        [GrammarCall("createShader")]
        public ShaderClassExpr CreateShader(string name, ListExpression<IShaderClassObjectExpr> objects,
             ListExpression<string>? bases, int type)
        {
            return new ShaderClassExpr(name, objects,
                bases ?? Enumerable.Empty<string>(), type);
        }
    }
}
