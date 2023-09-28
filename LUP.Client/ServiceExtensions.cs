using LUP.Client.Input;
using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    public static class ServiceExtensions
    {
        public static void AddDesktopWindow(this IServiceCollection services)
        {
            services.RegisterType<DesktopWindow>()
                .As<IDesktopWindow>().As<IWindow>().As<IInputHandler>().AsSelf()
                .AsSingleton();

            services.RegisterType<WindowProcessor>()
                .As<IWindowProcessor>().AsSelf()
                .AsSingleton();
        }


        public static void AddDesktopWindow(this IServiceCollection services, Action<WindowConfig> configAction)
        {
            services.Configure(configAction);
            services.AddDesktopWindow();
        }
    }
}
