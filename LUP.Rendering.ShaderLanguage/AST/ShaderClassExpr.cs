using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.AST
{
    public class ShaderClassExpr
    {
        public string Name { get; }

        public ShaderClassTypesExpr Type { get; }

        public ImmutableArray<IShaderClassObjectExpr> Objects { get; }

        public ImmutableArray<string> Bases { get; }

        public ShaderClassExpr(string name, 
            IEnumerable<IShaderClassObjectExpr> objects, IEnumerable<string> bases, int type)
        {
            Name = name;
            Type = (ShaderClassTypesExpr)Enum.ToObject(typeof(ShaderClassTypesExpr), type);
            Objects = objects.ToImmutableArray();
            Bases = bases.ToImmutableArray();
        }
    }


    public enum ShaderClassTypesExpr
    {
        None = 0,

        Vertex = 1,

        Pixel = 2,

        Geometry = 3,

        Compute = 4,

        Tessellation = 5
    }
}
