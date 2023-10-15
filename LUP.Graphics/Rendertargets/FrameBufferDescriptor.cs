using LUP.Graphics.Enums;
using LUP.Math;

namespace LUP.Graphics.Rendertargets
{
    public class FrameBufferDescriptor
    {
        public const int MaxColors = 12;

        public FBOTextureDescriptor?[] Colors { get; }

        public FBOTextureDescriptor? DepthStencil { get; }

        public Vector2 Size { get; }

        public FrameBufferDescriptor(Vector2 size) : this(null, size)
        {
        }


        public FrameBufferDescriptor(FBOTextureDescriptor? depthStencil, Vector2 size)
        {
            Size = size;
            DepthStencil = depthStencil;
            Colors = new FBOTextureDescriptor?[MaxColors];
        }


        public static FrameBufferDescriptor New(Vector2 size, FBOTextureDescriptor? depthStencil, params FBOTextureDescriptor[] colors)
        {
            var result = new FrameBufferDescriptor(depthStencil, size);

            for (int i = 0; i < MaxColors && i < colors.Length; i++)
                result.Colors[i] = colors[i];

            return result;
        }
    }


    public sealed record FBOTextureDescriptor(TextureDimensionTypes Type, TextureFormat Format);
}