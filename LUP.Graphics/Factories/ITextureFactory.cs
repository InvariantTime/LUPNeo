using LUP.Graphics.Enums;
using LUP.Graphics.Textures;

namespace LUP.Graphics.Factories
{
    public interface ITextureFactory
    {
        ITexture BuildTexture(TextureDimensionTypes types);

        ICubeTexture BuildCube();

        IEmptyTexture BuildEmpty(TextureTypes type);

        IArrayTexture BuildTextureArray();
    }
}
