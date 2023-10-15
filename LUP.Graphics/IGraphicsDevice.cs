using LUP.Graphics.Factories;

namespace LUP.Graphics
{
    public interface IGraphicsDevice
    {
        EffectFactory Effects { get; }

        ITextureFactory Textures { get; }

        FrameBufferFactory FBOs { get; }

        DataBufferFactory DataBuffers { get; }

        IConstantBuffer GetConstantBuffer(ConstantBufferKey key);

        IGraphicsCommandList GetCommandList();
    }
}
