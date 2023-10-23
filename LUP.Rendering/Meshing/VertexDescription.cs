using LUP.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public sealed class VertexDescription
    {
        public ImmutableArray<VertexElement> Elements { get; }

        public ImmutableArray<VertexAttribPointer> Pointers { get; }

        public VertexDescription(VertexElement[] elements) : this(elements.AsEnumerable())
        {
        }


        public VertexDescription(IEnumerable<VertexElement> elements)
        {
            Elements = elements.ToImmutableArray();
            Pointers = elements.Select(x => new VertexAttribPointer(x.Key.Index, x.Key.Size,
                x.Format, x.Stride, x.Offset)).ToImmutableArray();
        }
    }
}
