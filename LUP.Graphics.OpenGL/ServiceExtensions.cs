using LUP.Client;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Graphics.OpenGL.Commanding;
using LUP.Graphics.OpenGL.Resources;

namespace LUP.Graphics.OpenGL
{
    public static class ServiceExtensions
    {
        public static void AddOpenGL(this IServiceCollection services)
        {
            AddOpenGL(services, _ => { });
        }


        public static void AddOpenGL(this IServiceCollection services, Action<GLOptions> optionAction)
        {
            services.AddGraphicsDevice<GraphicsCommandList, OpenGLFactory>();
            services.RegisterType<OpenGLRenderer>().As<IWindowRenderer>();
        }
    }

    public class GLOptions
    {
        public GLOptions()
        {

        }
    }
}
