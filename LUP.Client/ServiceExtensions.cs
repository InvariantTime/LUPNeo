using LUP.Client.Input;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;

namespace LUP.Client
{
    public static class ServiceExtensions
    {
        public static void AddDesktopWindow(this IServiceCollection services)
        {
            services.RegisterType<DesktopWindow>()
                .As<IDesktopWindow>().As<IWindow>().AsSelf()
                .AsSingleton();

            services.RegisterType<WindowProcessor>()
                .As<IWindowProcessor>().AsSelf()
                .AsSingleton();

            services.RegisterType<InputProcessor>()
                .As<IInputProcessor>().AsSelf()
                .AsSingleton();

            services.RegisterFactory(x =>
            {
                var win = x.GetService<DesktopWindow>()
                    ?? throw new InvalidOperationException("There is no window");

                return win.Input;

            }).As<IInputHandler>().AsSingleton();
        }


        public static void AddDesktopWindow(this IServiceCollection services, Action<WindowConfig> configAction)
        {
            services.Configure(configAction);
            services.AddDesktopWindow();
        }
    }
}
