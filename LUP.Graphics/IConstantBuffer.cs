namespace LUP.Graphics
{
    public interface IConstantBuffer
    {
        int Binding { get; }

        int Size { get; }

        void SetData<T>(T data, int offset) where T : struct;

        void SetData(IntPtr data, IntPtr offset);
    }
}
