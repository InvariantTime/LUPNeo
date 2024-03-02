using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderStatementBlock : IShaderStatement
    {
        public ImmutableArray<IShaderStatement> Statements { get; }

        public ShaderStatementBlock(IEnumerable<IShaderStatement> statements)
        {
            Statements = statements.ToImmutableArray();
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T info)
        {
            visitor.Visit(this, info);
        }
    }
}
