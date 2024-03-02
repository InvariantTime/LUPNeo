
namespace LUP.Graphics
{
    public static class GraphicsContextDataExtension
    {
        public static void BindBuffer(this GraphicsContext context, GraphicsResource resource)
        {
            context.AddCommand(GraphicsCommands.BindBuffer, resource);
        }


        public static void UnbindBuffer(this GraphicsContext context, GraphicsResource resource)
        {
            context.AddCommand(GraphicsCommands.UnbindBuffer, resource);
        }


        public static void UpdateBuffer(this GraphicsContext context, GraphicsResource resource, BufferData data)
        {
            context.AddCommand(GraphicsCommands.UpdateBuffer, 
                new ValueTuple<GraphicsResource, BufferData>(resource, data));
        }
    }
}
