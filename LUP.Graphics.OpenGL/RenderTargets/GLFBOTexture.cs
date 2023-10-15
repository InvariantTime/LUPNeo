using LUP.Graphics.OpenGL.Textures;
using LUP.Graphics.Rendertargets;

namespace LUP.Graphics.OpenGL.RenderTargets
{
    class GLFBOTexture : FBOTexture
    {
        public new EmptyTexture Texture { get; }

        public int TextureIndex => Texture.Index;

        public GLFBOTexture(EmptyTexture texture) : base(texture)
        {
            Texture = texture;
        }
    }
}
