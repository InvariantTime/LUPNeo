using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST
{
    public class ShaderNamespace
    {
        public ShaderNamespaceID Name { get; }

        public ShaderNamespace(ShaderNamespaceID name)
        {
            Name = name;
        }
    }

    public class ShaderNamespaceID
    {
        public ShaderNamespaceID? Parent { get; }

        public string ID { get; }

        public ShaderNamespaceID(string id, ShaderNamespaceID? parent = null)
        {
            Parent = parent;
            ID = id;
        }
    }
}
