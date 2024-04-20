using LUP.Graphics;

namespace LUP.Rendering.Base
{
    public class RenderTargetSlot
    {
        public string Name { get; }

        public RenderTargetDescriptor Descriptor { get; }

        public RenderTargetSlot(string name, RenderTargetDescriptor descriptor)
        {
            Name = name;
            Descriptor = descriptor;
        }
    }
}
