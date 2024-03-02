namespace LUP.Graphics.Commanding
{
    public abstract class ShaderCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<GraphicsResource>(GraphicsCommands.BindShader, BindShader);
            collector.Collect(GraphicsCommands.UnbindBuffer, UnbindShader);
            collector.Collect<ShaderConstantBinding>(GraphicsCommands.BindShaderToConstantBuffer, BindShaderToConstantBuffer);
            collector.Collect<string, ValueType>(GraphicsCommands.SetUniform, SetShaderUniform);
        }


        public abstract void BindShader(GraphicsResource shader);

        public abstract void UnbindShader();

        public abstract void SetShaderUniform(string name, ValueType type);

        public abstract void BindShaderToConstantBuffer(ShaderConstantBinding binding);
    }
}
