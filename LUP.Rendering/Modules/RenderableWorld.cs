using LUP.Graphics;
using LUP.Math;
using LUP.Rendering.Pipeline;
using LUP.Rendering.RenderObjects;
using LUP.SceneGraph.Modules;

namespace LUP.Rendering.Modules
{
    public class RenderableWorld : ComponentWorld<IRenderProvider>
    {
        private readonly RenderCompositor compositor;
        private readonly IRenderPipeline pipeline;
        private readonly RenderTargetWorld renderTarget;

        public RenderableWorld(IRenderPipeline pipeline, RenderTargetWorld renderTarget)
        {
            this.renderTarget = renderTarget;
            this.pipeline = pipeline;

            compositor = new();
        }


        public override void Update()
        {
            if (renderTarget.Components.Count == 0)
                return;

            CollectCompositor();

            foreach (var camera in renderTarget.Components)
            {
                pipeline.Process(new RenderScene
                {
                    Compositor = compositor,
                    View = camera
                });
            }

            compositor.Clear();
        }

        
        private void CollectCompositor()
        {
            foreach (var component in Components)
            {
                if (component.Enable == false)
                    continue;

                component.Visit(compositor);
            }
        }
    }
}
