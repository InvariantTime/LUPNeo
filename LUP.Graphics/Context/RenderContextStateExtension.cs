
namespace LUP.Graphics
{
    public static class RenderContextStateExtension
    {
        public static void BindShader(this GraphicsContext context, GraphicsResource resource)
        {
            context.AddCommand(GraphicsCommands.BindShader, resource);
        }


        public static void UnbindShader(this GraphicsContext context)
        {
            context.AddCommand(GraphicsCommands.UnbindShader);
        }


        public static void SetShaderUniform(this GraphicsContext context, ShaderUniform uniform, ValueType value)
        {
            context.AddCommand(GraphicsCommands.SetUniform, uniform, value);
        }


        public static void BindConstantsToShader(this GraphicsContext context, ShaderConstantBinding binding)
        {
            context.AddCommand(GraphicsCommands.BindShaderToConstantBuffer, binding);
        }




        public static void SetGraphicsState(this GraphicsContext context, GraphicsState state)
        {
            context.AddCommand(GraphicsCommands.SetState, state);
        }


        //Textures
        public static void BindTexture(this GraphicsContext context, GraphicsResource resource)
        {
            context.AddCommand(GraphicsCommands.BindTexture, resource);
        }


        public static void UnbindTexture(this GraphicsContext context, GraphicsResource resource)
        {
            context.AddCommand(GraphicsCommands.UnbindTexture, resource);
        }


        public static void SetTextureIndex(this GraphicsContext context, uint index)
        {
            //TODO
        }


        public static void BindTexture()
        {

        }


        public static void UnbindTexture()
        {

        }


        public static void SetRenderTarget()
        {

        }


        public static void BindVertexFormat(this GraphicsContext context, VertexFormat format)
        {
            context.AddCommand(GraphicsCommands.BindVertexFormat, format);
        }


        public static void UnbindVertexFormat(this GraphicsContext context, VertexFormat format)
        {
            context.AddCommand(GraphicsCommands.UnbindVertexFormat, format);
        }
    }
}