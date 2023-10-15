using LUP.Graphics.Textures;
using LUP.Math;
using System.Collections.Immutable;

namespace LUP.Graphics.Rendertargets
{
    public interface IFrameBuffer : IDisposable
    {
        ImmutableArray<FBOTexture> Colors { get; }

        FBOTexture? DepthStencil { get; }

        Vector2 Size { get; }

        void Resize(Vector2 size);

        void Bind();

        void Unbind();
    }


    public class FBOTexture
    {
        public IEmptyTexture Texture { get; }

        public FBOTexture(IEmptyTexture texture)
        {
            Texture = texture;
        }
    }
}
