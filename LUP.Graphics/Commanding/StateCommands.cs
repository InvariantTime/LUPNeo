using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Commanding
{
    public abstract class StateCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<GraphicsState>(GraphicsCommands.SetState, SetState);
            collector.Collect<GraphicsResource>(GraphicsCommands.SetRenderTarget, SetRenderTarget);
        }

        
        public abstract void SetState(GraphicsState state);

        public abstract void SetRenderTarget(GraphicsResource renderTarget);
    }
}
