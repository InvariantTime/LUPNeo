using LUP.Graphics.Enums;
using LUP.Graphics.Textures;
using LUP.Math;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Textures
{
    class Texture : DisposableObject, ITexture
    {
        private readonly RawTexture handle;

        public TextureTypes Type { get; }

        public int Index => handle.Index;

        public Texture(TextureDimensionTypes type)
        {
            Type = (TextureTypes)type;
            handle = new(OpenGLConverter.Convert(Type));
        }


        public void Bind()
        {
            handle.Bind();
        }


        public void Unbind()
        {
            handle.Unbind();
        }


        public void SetData<T>(Vector2 size, TextureFormat format, T[] data) where T : struct
        {
            handle.Bind();
            GL.TexImage2D(handle.Target, 0, 0, (int)size.X, (int)size.Y, 0,
                OpenGLConverter.Convert(format.Format), OpenGLConverter.Convert(format.Type), data);
            handle.Unbind();
        }
    }
}
