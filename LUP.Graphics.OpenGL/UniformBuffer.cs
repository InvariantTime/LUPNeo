using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    sealed class UniformBuffer : DisposableObject, IConstantBuffer
    {
        private readonly int index;

        public int Size { get; }

        public int Binding { get; }

        public UniformBuffer(int size, int binding)
        {
            Size = size;
            Binding = binding;

            index = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.UniformBuffer, index);
            GL.BufferData(BufferTarget.UniformBuffer, size, 0, BufferUsageHint.DynamicDraw);
            GL.BindBufferBase(BufferRangeTarget.UniformBuffer, binding, index);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        public void SetData<T>(T data, int offset) where T : struct
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, index);
            GL.BufferSubData(BufferTarget.UniformBuffer, offset, Size, ref data);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        public void SetData(IntPtr data, IntPtr offset)
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, index);
            GL.BufferSubData(BufferTarget.UniformBuffer, offset, Size, data);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        protected override void OnManagedDisposed()
        {
            GL.DeleteBuffer(index);
        }
    }
}
