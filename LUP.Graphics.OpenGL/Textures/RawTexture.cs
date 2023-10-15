using OpenTK.Graphics.OpenGL;

namespace LUP.Graphics.OpenGL.Textures
{
    class RawTexture
    {
        public int Index { get; }

        public TextureTarget Target { get; }

        public RawTexture(TextureTarget target)
        {
            Target = target;
            Index = GL.GenTexture();
        }


        public void Bind()
        {
            GL.BindTexture(Target, Index);
        }


        public void Unbind()
        {
            GL.BindTexture(Target, 0);
        }
    }
}
