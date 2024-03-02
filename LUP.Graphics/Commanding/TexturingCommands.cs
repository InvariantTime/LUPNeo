using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Commanding
{
    public abstract class TexturingCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<GraphicsResource>(GraphicsCommands.BindTexture, BindTexture);
            collector.Collect<GraphicsResource>(GraphicsCommands.UnbindTexture, UnbindTexture);
            collector.Collect<uint>(GraphicsCommands.SetTextureSlot, SetTextureSlot);
        }


        public abstract void BindTexture(GraphicsResource texture);

        public abstract void UnbindTexture(GraphicsResource texture);

        public abstract void SetTextureSlot(uint index);
    }
}
