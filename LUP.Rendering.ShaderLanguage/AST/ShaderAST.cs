using LUP.Parsing;
using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST
{
    public class ShaderAST : IASTExpression
    {
        public ImmutableArray<ShaderNamespaceID> Usings { get; }

        public ImmutableArray<ShaderNamespace> Namespaces { get; }

        public ShaderAST(IEnumerable<ShaderNamespaceID> usings, IEnumerable<ShaderNamespace> namespaces)
        {
            Usings = usings.ToImmutableArray();
            Namespaces = namespaces.ToImmutableArray();
        }
    }
}
