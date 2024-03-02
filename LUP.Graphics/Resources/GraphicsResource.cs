using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics
{
    public readonly struct GraphicsResource
    {
        public static readonly GraphicsResource Empty = new();

        public uint Reference { get; init; }

        public GraphicsResourceTypes Type { get; init; }

        public GraphicsResource(uint reference, GraphicsResourceTypes type)
        {
            Reference = reference;
            Type = type;
        }


        public GraphicsResource()
        {
            Reference = uint.MaxValue;
        }


        public override bool Equals(object? obj)
        {
            return obj is GraphicsResource resource &&
                   Reference == resource.Reference &&
                   Type == resource.Type;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Reference);
        }


        public static bool operator ==(GraphicsResource left, GraphicsResource right)
        {
            return left.Equals(right);
        }


        public static bool operator !=(GraphicsResource left, GraphicsResource right)
        {
            return !(left == right);
        }


        public override string ToString()
        {
            return $"{{{Type}, {Reference}}}";
        }
    }

    public enum GraphicsResourceTypes
    {
        Texture = 1,

        Buffer = 2,

        Shader = 3,

        RenderTarget = 4
    }
}
