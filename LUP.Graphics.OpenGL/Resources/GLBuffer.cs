using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Resources
{
    class GLBuffer : GLResource, IGLBuffer
    {
        private readonly int index;
        private readonly BufferTarget target;
        private readonly BufferUsageHint usage;

        public GLBuffer(BufferTarget target, BufferData data)
        {
            this.target = target;
            index = GL.GenBuffer();
            GL.BindBuffer(target, index);
            GL.BufferData(target, data.Size, data.Pointer, BufferUsageHint.StaticDraw);
            GL.BindBuffer(target, 0);
        }


        public override void Bind()
        {
            GL.BindBuffer(target, index);   
        }


        public override void Unbind()
        {
            GL.BindBuffer(target, 0);
        }


        public void Update(BufferData data, int offset)
        {

        }


        public override void Dispose()
        {
            GL.DeleteBuffer(index);
        }


        public override int GetIndex()
        {
            return index;
        }
    }
}
