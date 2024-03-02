using LUP.Graphics.Enums;

namespace LUP.Rendering.Language.Generation
{
    public static class ShaderMethods
    {
        public static readonly KeyValuePair<string, ShaderTypes>[] Methods =
        {
            new("PsMain", ShaderTypes.Pixel),
            new("VsMain", ShaderTypes.Vertex),
            new("GsMain", ShaderTypes.Geometry)
        };
    }
}
