namespace LUP.Graphics.OpenGL.Textures
{
    class TextureCube
    {
        private readonly RawTexture handle;

        public int Index => handle.Index;

        public TextureCube(RawTexture raw)
        {
            this.handle = raw;
        }
    }
}
