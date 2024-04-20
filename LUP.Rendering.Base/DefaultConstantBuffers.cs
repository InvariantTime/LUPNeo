using LUP.Graphics.Resources;
using LUP.Rendering.Data;

namespace LUP.Rendering
{
    public static class DefaultConstantBuffers
    {
        public static readonly ConstantBufferDescriptor SceneData = new(1, SceneRenderData.Size);

        //Lighting
        public static readonly ConstantBufferDescriptor DirectionLightData = new(5, 0);

        public static readonly ConstantBufferDescriptor PointLightData = new(6, 0);

        public static readonly ConstantBufferDescriptor SpotLightData = new(7, 0);
    }
}
