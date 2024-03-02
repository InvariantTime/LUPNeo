using System.Collections.Immutable;

namespace LUP.Rendering.Language
{
    public class ShaderClassType
    {
        public ImmutableArray<ShaderClass> Bases { get; }

        public string Name { get; }

        public ShaderClassType(string name, IEnumerable<ShaderClass> bases)
        {
            Bases = bases.ToImmutableArray();
            Name = name;
        }

        public bool IsBaseFor(ShaderClass @class)
        {
            return false;
        }
    }
}
