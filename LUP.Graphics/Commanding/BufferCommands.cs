using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Commanding
{
    public abstract class BufferCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<GraphicsResource>(GraphicsCommands.BindBuffer, BindBuffer);
            collector.Collect<GraphicsResource>(GraphicsCommands.UnbindBuffer, UnbindBuffer);
            collector.Collect<GraphicsResource, BufferData>(GraphicsCommands.UpdateBuffer, UpdateBuffer);
        }

        
        public abstract void BindBuffer(GraphicsResource buffer);

        public abstract void UnbindBuffer(GraphicsResource buffer);

        public abstract void UpdateBuffer(GraphicsResource buffer, BufferData data);
    }
}
