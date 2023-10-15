using LUP.Graphics.Enums;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL
{
    public class DataBuffer : DisposableObject, IDataBuffer
    {
        private readonly BufferTarget target;
        private readonly int index;

        public BufferTypes Type { get; }

        public DataBuffer(BufferTypes type)
        {
            Type = type;
            index = GL.GenBuffer();
            target = OpenGLConverter.Convert(type);
        }


        public void Bind()
        {
            GL.BindBuffer(target, index);
        }


        public void SetData<T>(T[] data, int size, BufferUsages usage) where T : struct
        {
            Bind();
            GL.BufferData(target, size, data, OpenGLConverter.Convert(usage));
            Unbind();
        }


        public void SetData(nint data, int size, BufferUsages usage)
        {
            Bind();
            GL.BufferData(target, size, data, OpenGLConverter.Convert(usage));
            Unbind();
        }


        public void Unbind()
        {
            GL.BindBuffer(target, 0);
        }
    }
}
