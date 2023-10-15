using LUP.Math;

namespace LUP.Graphics.Textures
{
    public interface ITexture : ITextureBase
    {
        void SetData<T>(Vector2 size, TextureFormat format, T[] data) where T : struct;
    }
}
