using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST.Handlers
{
    class ShaderModulesHandler
    {
        [GrammarCall("createAST")]
        public ShaderAST CreateAST(ListExpression<ShaderNamespaceID> usings, ListExpression<ShaderNamespace> namespaces)
        {
            return new ShaderAST(usings, namespaces);
        }


        [GrammarCall("createNamespace")]
        public ShaderNamespace CreateNamespace(ShaderNamespaceID id)
        {
            return new ShaderNamespace(id);
        }


        [GrammarCall("createNamespaceID")]
        public ShaderNamespaceID CreateNamespaceID(string id)
        {
            return new ShaderNamespaceID(id);
        }


        [GrammarCall("createNamespaceID")]
        public ShaderNamespaceID CreateNamespaceID(string id, ShaderNamespaceID parent)
        {
            return new ShaderNamespaceID(id, parent);
        }
    }
}
