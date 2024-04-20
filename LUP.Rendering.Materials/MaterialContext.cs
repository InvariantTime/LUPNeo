using LUP.Graphics.Enums;
using LUP.Rendering.Materials.Sources;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace LUP.Rendering.Materials
{
    public class MaterialContext
    {
        private readonly HashSet<MaterialParameter> parameters;
        private readonly Dictionary<ShaderTypes, MaterialSource> sources;

        public IReadOnlyDictionary<ShaderTypes, MaterialSource> Sources { get; }

        public MaterialContext()
        {
            sources = new();
            parameters = new(HashSetComparer.Instance);

            Sources = new ReadOnlyDictionary<ShaderTypes, MaterialSource>(sources);
        }


        public void AddParameter(MaterialParameter parameter)
        {
            parameters.Add(parameter);
        }


        public void AddSource(ShaderTypes type, MaterialSource source)
        {
            if (sources.ContainsKey(type) == true)
                throw new Exception("There is already such source");

            sources.Add(type, source);
        }


        public IEnumerable<MaterialParameter> GetParameters()
        {
            return parameters.ToArray();
        }


        private class HashSetComparer : IEqualityComparer<MaterialParameter>
        {
            public static readonly HashSetComparer Instance = new();

            public bool Equals(MaterialParameter? x, MaterialParameter? y)
            {
                return x?.Key == y?.Key;
            }


            public int GetHashCode([DisallowNull] MaterialParameter obj)
            {
                return obj.Key.GetHashCode();
            }
        }
    }
}
