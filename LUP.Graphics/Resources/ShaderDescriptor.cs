using LUP.Graphics.Enums;

namespace LUP.Graphics.Resources
{
    public readonly struct ShaderDescriptor
    {
        public ShaderPart[] Parts { get; init; }

        public ShaderDescriptor(IEnumerable<ShaderPart> parts)
        {
            Parts = parts.ToArray();
        }
    }

    public readonly struct ShaderPart
    {
        public ShaderTypes Type { get; init; }

        public string Source { get; init; }

        public ShaderPart(ShaderTypes type, string source)
        {
            Type = type;
            Source = source;
        }
    }
}
