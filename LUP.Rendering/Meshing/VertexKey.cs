using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public sealed class VertexKey
    {
        public string Name { get; }

        public int Index { get; }

        public int Size { get; }

        private VertexKey(string name, int index, int size)
        {
            Name = name;
            Index = index;
            Size = size;
        }


        public static VertexKey New(string name, int index, int size)
        {
            return new VertexKey(name, index, size);
        }
    }
}
