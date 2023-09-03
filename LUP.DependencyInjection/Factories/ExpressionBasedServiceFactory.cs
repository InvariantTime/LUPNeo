using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.Factories
{
    public class ExpressionBasedServiceFactory : IServiceFactory
    {
        private static readonly MethodInfo resolveMethod = typeof(ExpressionBasedServiceFactory)
            .GetMethod(nameof(Resolve), BindingFlags.NonPublic | BindingFlags.Static)!;

        private readonly ConcurrentDictionary<Type, Func<IServiceScope, object?>> builders = new();

        public object? CreateService(ServiceDescriptor descriptor, IServiceScope scope)
        {
            if (descriptor is SingletonServiceDescriptor ssd)
                return ssd.Instance;

            if (descriptor is FactoryServiceDescriptor fsd)
                return fsd.Factory;

            if (descriptor is DynamicServiceDescriptor dsd)
            {
                var builder = builders.GetOrAdd(dsd.Implementation, CreateBuilder);
                return builder.Invoke(scope);
            }

            return null;
        }


        private static Func<IServiceScope, object?> CreateBuilder(Type type)
        {
            var ctor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();

            if (ctor == null)
                throw new InvalidOperationException("Unable to create object");

            var scopeParameter = Expression.Parameter(typeof(IServiceScope), "scope");

            var parameters = ctor.GetParameters().Select(x => Expression.Convert(
                Expression.Call(resolveMethod, scopeParameter, Expression.Constant(x.ParameterType)), x.ParameterType));
            var @new = Expression.New(ctor, parameters);
            var lambda = Expression.Lambda<Func<IServiceScope, object?>>(@new, scopeParameter);

            return lambda.Compile();
        }


        private static object? Resolve(IServiceScope scope, Type type)
        {
            return scope.Services.GetService(type);
        }
    }
}
