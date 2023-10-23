namespace LUP.Rendering.Pipeline
{
    public interface IRenderPipeline
    {
        IEnumerable<RootRenderStep> Steps { get; }

        void Process(RenderScene scene);
    }
}
