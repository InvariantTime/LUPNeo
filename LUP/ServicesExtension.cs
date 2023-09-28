using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public static class ServicesExtension
    {
        public static void Configure<T>(this IServiceCollection services, Action<T> configAction) where T : new()
        {
            Option<T> config = new(new T());

            services.RegisterInstance(config)
                .As<IOption<T>>()
                .AsSelf()
                .OnActivated(x => configAction?.Invoke(config.Accessor))
                .AsSingleton();
        }
    }
}
