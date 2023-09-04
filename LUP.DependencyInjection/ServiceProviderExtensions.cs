using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static T? GetService<T>(this IServicesProvider provider)
        {
            var result = provider.GetService(typeof(T));

            return (T?)result;
        }


        public static T? GetService<T>(this IServiceScope scope)
        {
            return scope.Services.GetService<T>();
        }


        public static object? GetService(this IServiceScope scope, Type type)
        {
            return scope.Services.GetService(type);
        }
    }
}
