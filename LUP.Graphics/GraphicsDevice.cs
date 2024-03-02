using LUP.Graphics.Commanding;
using LUP.Logging;

namespace LUP.Graphics
{
    public class GraphicsDevice
    {
        private readonly Action<GraphicsCommand> resolver;
        private readonly IResourceFactory factory;
        private readonly ILogger<GraphicsDevice> logger;

        public GraphicsDevice(IGraphicsCommandList list, IResourceFactory factory, ILogger<GraphicsDevice> logger)
        {
            this.factory = factory;
            this.logger = logger;

            resolver = CommandResolverBuilder.Build(list);
        }


        public void Dispatch(GraphicsContext context, GraphicsAllocator allocator)
        {
            allocator.Execute(factory);

            try
            {

                foreach (var command in context)
                    resolver?.Invoke(command);
            }
            catch(Exception e)
            {
                logger.Error("resolve command error", e);
            }

            allocator.Clear();
        }


        public void Dispatch(GraphicsAllocator allocator)
        {
            allocator.Execute(factory);
            allocator.Clear();
        }
    }
}
