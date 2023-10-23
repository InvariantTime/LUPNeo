using LUP.Graphics;
using LUP.Rendering.Meshing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Pipeline
{
    public abstract class RenderStep
    {
        private GraphicsContext? context;

        public GraphicsContext Context
        {
            get
            {
                if (context == null)
                    throw new InvalidOperationException("Step is not initialized");

                return context;
            }
        }


        public void Initialize(GraphicsContext context, IRenderPipeline pipeline)
        {
            this.context = context;
            OnInitialize(pipeline);
        }


        protected virtual void Sort()
        {
        }


        protected virtual void OnInitialize(IRenderPipeline pipeline)
        {
        }


        public virtual void Prepare(RenderScene scene)
        {
        }


        public virtual void Draw(RenderScene scene)
        {
        }
    }

    public sealed class GraphicsContext
    {
        public IGraphicsDevice Device { get; }

        public GraphicsContext(IGraphicsDevice device)
        {
            Device = device;
        }
    }
}
