using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars
{
    public sealed record ReduceParam
    {
        public string Name { get; set; }
        
        public ImmutableArray<int> TokenIndices { get; set; }

        public ReduceParam(string name, IEnumerable<int> tokenIndices)
        {
            Name = name;
            TokenIndices = tokenIndices.ToImmutableArray();
        }
    }
}
