using LUP.Graphics;
using LUP.Rendering.Pipeline.Steps;
using LUP.Rendering.RenderObjects;
using LUP.Rendering.RenderTargets;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Pipeline
{
    public class ImmutableRenderPipeline : IRenderPipeline
    {
        private readonly ImmutableQueue<RootRenderStep> steps;

        public IEnumerable<RootRenderStep> Steps => steps;

        public GraphicsContext Context { get; }

        public ImmutableRenderPipeline(GraphicsContext context)
        {
            Context = context;

            steps = ImmutableQueue<RootRenderStep>.Empty.Enqueue(new MeshRenderStep()).Enqueue(new SceneDataRenderStep());

            foreach (var step in steps)
                step.Initialize(context, this);
        }


        public void Process(RenderScene scene)
        {
            Context.Device.GetCommandList().Clear();

            foreach (var step in steps)
                step.Prepare(scene);

            foreach (var step in steps)
                step.Draw(scene);
        }
    }
}