using LUP.Graphics.Rendertargets;

namespace LUP.Graphics
{
    public interface IRenderTarget
    {
        IFrameBuffer? FBO { get; }
    }
}