using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderForStatement : IShaderStatement
    {
        public IShaderStatement Body { get; }

        public IShaderExpression? Param { get; }

        public IShaderExpression? Condition { get; }

        public IShaderExpression? Step { get; }

        public ShaderForStatement(IShaderStatement body, 
            IShaderExpression? param = null, IShaderExpression? condition = null, IShaderExpression? step = null)
        {
            Body = body;
            Param = param;
            Condition = condition;
            Step = step;
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T context)
        {
            visitor.Visit(this, context);
        }
    }
}
