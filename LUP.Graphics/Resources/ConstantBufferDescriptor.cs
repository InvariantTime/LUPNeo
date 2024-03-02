
namespace LUP.Graphics.Resources
{
    public readonly struct ConstantBufferDescriptor
    {
        public int Index { get; init; }

        public int Size { get; init; }

        public ConstantBufferDescriptor(int index, int size)
        {
            Index = index;
            Size = size;
        }


        public override bool Equals(object? obj)
        {
            return obj is ConstantBufferDescriptor descriptor &&
                   Index == descriptor.Index &&
                   Size == descriptor.Size;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Index, Size);
        }


        public static bool operator ==(ConstantBufferDescriptor left, ConstantBufferDescriptor right)
        {
            return left.Equals(right);
        }


        public static bool operator !=(ConstantBufferDescriptor left, ConstantBufferDescriptor right)
        {
            return left.Equals(right);
        }
    }
}
