using LUP.Graphics.Enums;

namespace LUP.Graphics
{
    public static class GraphicsContextDrawExtension
    {
        public static void Clear(this GraphicsContext context, ClearMask mask)
        {
            context.AddCommand(GraphicsCommands.Clear, mask);
        }


        public static void Draw(this GraphicsContext context, DrawData data)
        {
            context.AddCommand(GraphicsCommands.Draw, data);
        }
    }
}
