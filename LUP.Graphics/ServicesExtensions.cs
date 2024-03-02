using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Graphics.Commanding;

namespace LUP.Graphics
{
    public static class ServicesExtensions
    {
        public static void AddGraphicsDevice<TList, TFactory>(this IServiceCollection services)
            where TList : IGraphicsCommandList where TFactory : IResourceFactory
        {
            services.RegisterType<GraphicsDevice>().AsSelf().AsSingleton();

            services.RegisterType<TList>().AsSelf()
                .As<IGraphicsCommandList>().AsSingleton();

            services.RegisterType<TFactory>().AsSelf()
                .As<IResourceFactory>().AsSingleton();
        }
    }
}
