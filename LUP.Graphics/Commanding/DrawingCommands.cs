using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Graphics.Commanding
{
    public abstract class DrawingCommands : IGraphicsCommandProvider
    {
        public void InitializeCommands(IGraphicsCommandCollector collector)
        {
            collector.Collect<ClearMask>(GraphicsCommands.Clear, Clear);
            collector.Collect<DrawData>(GraphicsCommands.Draw, Draw);
            collector.Collect<VertexFormat>(GraphicsCommands.BindVertexFormat, BindVertexFormat);
            collector.Collect<VertexFormat>(GraphicsCommands.UnbindVertexFormat, UnbindVertexFormat);
            collector.Collect<DrawInstanceData>(GraphicsCommands.DrawInstance, DrawInstance);
        }

        public abstract void Draw(DrawData data);

        public abstract void DrawInstance(DrawInstanceData data);

        public abstract void BindVertexFormat(VertexFormat format);

        public abstract void UnbindVertexFormat(VertexFormat format);

        public abstract void Clear(ClearMask mask);
    }
}
