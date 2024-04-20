using LUP.Rendering.Effects.Generation;

namespace LUP.Rendering.Materials.Resources
{
    public static class MaterialCBuffers
    {
        public static readonly ShaderCBuffer Scene = new()
        {
            Binding = 1,
            Alias = "_scene",
            Name = "SceneData",
            Params = new[]
            {
                new ShaderParam("mat4", "projection"),
                new ShaderParam("mat4", "view"),
                new ShaderParam("mat4", "positionlessView"),
                new ShaderParam("float", "time"),
                new ShaderParam("vec3", "viewPosition"),
                new ShaderParam("vec2", "viewportSize"),
                new ShaderParam("vec2", "outputSize"),
                new ShaderParam("float", "zFar"),
                new ShaderParam("float", "zNear")
            }
        };
    }
}
