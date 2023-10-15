using LUP.Client;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;

namespace LUP.Graphics.OpenGL
{
    public static class ServiceExtensions
    {
        public static void AddOpenGL(this IServiceCollection services)
        {
            AddOpenGL(services, _ => { });
        }


        public static void AddOpenGL(this IServiceCollection services, Action<GraphicsOptions> optionAction)
        {
            services.RegisterType<OpenGLRenderer>()
                .As<IWindowRenderer>().As<IRenderTarget>()
                .As<IGlobalRenderTarget>()
                .AsSelf().AsSingleton();

            services.RegisterType<OpenGLDevice>()
                .AsSelf().As<IGraphicsDevice>()
                .AsSingleton();

            services.RegisterType<CommandList>()
                .AsSelf().As<IGraphicsCommandList>()
                .AsSingleton();

            services.Configure(optionAction);
        }
    }
}
