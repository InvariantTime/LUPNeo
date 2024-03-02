using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST
{
    public class ShaderScope
    {
        private readonly Dictionary<string, IShaderIdentifier> identifiers;

        public ShaderScope? Parent { get; }

        public ShaderScope(ShaderScope? parent)
        {
            Parent = parent;
        }


        public ShaderScope() : this(null)
        {
        }


        public bool AddIdentifier(IShaderIdentifier identifier)
        {
            if (identifiers.ContainsKey(identifier.Name) == true)
                return false;

            identifiers.Add(identifier.Name, identifier);
            return true;
        }


        public ShaderScope Push()
        {
            return new ShaderScope(this);
        }


        public IShaderIdentifier? GetIdentifier(string name)
        {
            identifiers.TryGetValue(name, out var identifier);

            return identifier;
        }
    }
}
