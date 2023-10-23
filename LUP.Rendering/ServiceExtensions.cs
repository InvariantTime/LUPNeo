using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Rendering.Materials;
using LUP.Rendering.Modules;
using LUP.Rendering.Pipeline;
using LUP.Rendering.ShaderLanguage;
using LUP.SceneGraph;

namespace LUP.Rendering
{
    public static class ServiceExtensions
    {
        public static void AddRendering(this IServiceCollection services)
        {
            services.AddModule<RenderableWorld>();
            services.AddModule<RenderTargetWorld>();

            services.RegisterType<GraphicsContext>()
                .AsSelf().AsSingleton();

            services.RegisterFactory(BuildPipeline)
                .As<IRenderPipeline>().AsSelf()
                .AsSingleton();

            services.RegisterType<ShaderCompiler>()
                .AsSelf().AsSingleton();

            services.RegisterType<RenderMaterialBuilder>()
                .AsSelf().AsSingleton();
        }


        private static ImmutableRenderPipeline BuildPipeline(IServiceScope scope)
        {
            var context = scope.GetService<GraphicsContext>()
                ?? throw new InvalidOperationException("Unable to get graphics context");

            return new ImmutableRenderPipeline(context);
        }
    }
}
