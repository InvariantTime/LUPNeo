using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLUniformBuffer : GLResource, IGLBuffer
    {
        private readonly int buffer;

        public int Size { get; }

        public GLUniformBuffer(int size, int index)
        {
            Size = size;

            buffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.UniformBuffer, buffer);
            GL.BufferData(BufferTarget.UniformBuffer, size, 0, BufferUsageHint.DynamicDraw);
            GL.BindBufferBase(BufferRangeTarget.UniformBuffer, index, buffer);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        public void Update(BufferData data, int offset)
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, buffer);
            GL.BufferSubData(BufferTarget.UniformBuffer, offset, data.Size, data.Pointer);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        public override void Bind()
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, buffer);
        }


        public override void Unbind()
        {
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);
        }


        public override void Dispose()
        {
            GL.DeleteBuffer(buffer);
        }


        public override int GetIndex()
        {
            return buffer;
        }
    }
}
