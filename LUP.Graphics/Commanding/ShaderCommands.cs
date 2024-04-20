using LUP.Graphics.Enums;

namespace LUP.Graphics.Commanding
{
    public abstract class ShaderCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<GraphicsResource>(GraphicsCommands.BindShader, BindShader);
            collector.Collect(GraphicsCommands.UnbindShader, UnbindShader);
            collector.Collect<ShaderConstantBinding>(GraphicsCommands.BindShaderToConstantBuffer, BindShaderToConstantBuffer);
            collector.Collect<ShaderUniform, ValueType>(GraphicsCommands.SetUniform, SetShaderUniform);
        }


        public abstract void BindShader(GraphicsResource shader);

        public abstract void UnbindShader();

        public abstract void SetShaderUniform(ShaderUniform uniform, ValueType type);

        public abstract void BindShaderToConstantBuffer(ShaderConstantBinding binding);
    }
}
