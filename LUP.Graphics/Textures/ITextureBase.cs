using LUP.Graphics.Enums;

namespace LUP.Graphics.Textures
{
    public interface ITextureBase : IDisposable
    {
        TextureTypes Type { get; }

        void Bind();

        void Unbind();
    }
}
