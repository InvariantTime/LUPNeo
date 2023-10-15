using LUP.Graphics.Enums;

namespace LUP.Graphics.OpenGL.Factories
{
    static class GLDataBufferFactory
    {
        public static IDataBuffer Build(BufferTypes type)
        {
            return new DataBuffer(type);
        }
    }
}
