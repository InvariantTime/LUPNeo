namespace LUP.Graphics
{
    public class ConstantBufferKey
    {
        public string Name { get; }

        public int Size { get; }

        public int Binidng { get; }

        private ConstantBufferKey(string name, int size, int binidng)
        {
            Name = name;
            Size = size;
            Binidng = binidng;
        }


        public static ConstantBufferKey New(string name, int size, int binding)
        {
            return new ConstantBufferKey(name, size, binding);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
