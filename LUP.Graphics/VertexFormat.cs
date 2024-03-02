using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public class VertexFormat
    {
        public ImmutableArray<VertexAttribute> Attributes { get; }

        public VertexFormat(IEnumerable<VertexAttribute> attributes)
        {
            Attributes = attributes.ToImmutableArray();
        }
    }
}
