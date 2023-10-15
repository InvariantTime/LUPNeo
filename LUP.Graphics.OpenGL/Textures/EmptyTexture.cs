using LUP.Graphics.Enums;
using LUP.Graphics.Textures;
using LUP.Math;
using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Textures
{
    class EmptyTexture : DisposableObject, IEmptyTexture
    {
        private readonly RawTexture handle;
        private readonly TextureFormat format;

        public TextureTypes Type { get; }

        public int Index => handle.Index;

        public EmptyTexture(Vector2 size, TextureDimensionTypes type, TextureFormat format)
        {
            Type = (TextureTypes)type;
            this.format = format;

            handle = new(OpenGLConverter.Convert(Type));
            handle.Bind();

            SetEmptyData(Type, format, size);
            GL.TextureParameter(handle.Index, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TextureParameter(handle.Index, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            handle.Unbind();
        }


        public void Bind()
        {
            handle.Bind();
        }


        public void Unbind()
        {
            handle.Unbind();
        }


        public void Resize(Vector2 size)
        {
            handle.Bind();
            SetEmptyData(Type, format, size);
            handle.Unbind();
        }


        protected override void OnManagedDisposed()
        {
            GL.DeleteTexture(handle.Index);
        }


        private static void SetEmptyData(TextureTypes type, TextureFormat format, Vector2 size)
        {
            //TODO: other texture types
            if (type == TextureTypes.Texture2D)
            {
                GL.TexImage2D(OpenGLConverter.Convert(type), 0, (PixelInternalFormat)format.Code, (int)size.X, (int)size.Y, 0,
                    OpenGLConverter.Convert(format.Format), OpenGLConverter.Convert(format.Type), IntPtr.Zero);
            }
        }
    }
}
