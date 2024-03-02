using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderReturnStatement : IShaderStatement
    {
        public IShaderExpression? Expression { get; }

        public ShaderReturnStatement(IShaderExpression expression)
        {
            Expression = expression;
        }


        public ShaderReturnStatement()
        {
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T context)
        {
            visitor.Visit(this, context);
        }
    }
}
