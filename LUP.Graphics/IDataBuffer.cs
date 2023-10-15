using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public interface IDataBuffer
    {
        BufferTypes Type { get; }

        void SetData<T>(T[] data, int size, BufferUsages usage) where T : struct;

        void SetData(IntPtr data, int size, BufferUsages usage);

        void Bind();

        void Unbind();
    }
}
