using LUP.Graphics.Enums;
using LUP.Graphics.Factories;
using LUP.Graphics.OpenGL.Textures;
using LUP.Graphics.Textures;


namespace LUP.Graphics.OpenGL.Factories
{
    public class TextureFactory : ITextureFactory
    {
        public ICubeTexture BuildCube()
        {
            throw new NotImplementedException();
        }


        public IEmptyTexture BuildEmpty(TextureTypes type)
        {
            throw new NotImplementedException();
        }


        public ITexture BuildTexture(TextureDimensionTypes type)
        {
            var texture = new Texture(type);
            return texture;
        }


        public IArrayTexture BuildTextureArray()
        {
            throw new NotImplementedException();
        }
    }
}
