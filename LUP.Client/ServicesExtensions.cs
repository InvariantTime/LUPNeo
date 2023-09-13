using LUP.DependencyInjection;
using Silk.NET.SDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client
{
    public static class ServicesExtensions
    {
        public static void AddDesktopClient(IServiceCollection services) => AddDesktopClient(services, _ => { });


        public static void AddDesktopClient(IServiceCollection services, Action<DesktopSettings> optionAction)
        {
            services.AddSingleton<IWindow, Window>();
        }
    }
}
