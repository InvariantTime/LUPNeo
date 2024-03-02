using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderExpressionStatement : IShaderStatement
    {
        public IShaderExpression Expression { get; }

        public ShaderExpressionStatement(IShaderExpression expression)
        {
            Expression = expression;
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T info)
        {
            visitor.Visit(this, info);
        }
    }
}
