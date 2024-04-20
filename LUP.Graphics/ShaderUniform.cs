using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public readonly struct ShaderUniform
    {
        public string Name { get; init; }

        public ShaderUniformTypes Type { get; init; }

        public ShaderUniform(string name, ShaderUniformTypes type)
        {
            Name = name;
            Type = type;
        }
    }
}
