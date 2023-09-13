using LUP.DependencyInjection.Resolve;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace LUP.DependencyInjection.Factories
{
    class ExpressionBasedFactory : IServiceFactory
    {
        private static readonly ConcurrentDictionary<Type, Func<IServiceScope, object?>> factories = new();
        private static readonly MethodInfo getServiceMethod =
            typeof(ExpressionBasedFactory).GetMethod(nameof(GetService), BindingFlags.NonPublic | BindingFlags.Static)!;

        public object? Create(InstanceCallsite activator, IServiceScope scope)
        {

            if (activator.Value != null)
                return activator.Value;

            if (activator.Factory != null)
                return activator.Factory(scope);

            if (activator.Implementation != null)
                return factories.GetOrAdd(activator.Implementation, CreateFactory)?.Invoke(scope);

            return null;
        }


        private static Func<IServiceScope, object?> CreateFactory(Type type)
        {
            var ctor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(x => x.GetParameters().Length).FirstOrDefault();

            if (ctor == null)
                return _ => null;

            var scope = Expression.Parameter(typeof(IServiceScope), "scope");
            var ps = ctor.GetParameters().Select(x =>
            Expression.Convert(Expression.Call(getServiceMethod, scope, Expression.Constant(x.ParameterType)), x.ParameterType));
            var @new = Expression.New(ctor, ps);

            var lambda = Expression.Lambda<Func<IServiceScope, object?>>(@new, scope);
            return lambda.Compile();
        }


        private static object? GetService(IServiceScope scope, Type type)
        {
            return scope.Services.GetService(type);
        }
    }
}
