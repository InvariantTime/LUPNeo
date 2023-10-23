using LUP.DependencyInjection.Factories;
using LUP.DependencyInjection.Resolve;

namespace LUP.DependencyInjection
{
    public class ServiceProviderEngine
    {
        public IServiceFactory Factory { get; }

        public ServiceProviderEngine()
        {
            Factory = new ExpressionBasedFactory();
        }


        internal object? Resolve(ResolveContext context)
        {
            if (context.Callsite is EnumerableCallsite ecs)
                return ResolveEnumerable(ecs, context.Scope);

            if (context.Callsite is InstanceCallsite ics)
            {
                if (ics.Lifetime == ServiceLifetimes.Transient)
                    return ResolveInstance(ics, context.Scope);

                var scope = ics.Lifetime switch
                {
                    ServiceLifetimes.Singleton => context.Root,
                    ServiceLifetimes.Scoped => context.Scope,
                    _ => throw new NotSupportedException()
                };

                var contains = scope.TryGetService(context.Callsite, out var service);

                if (contains == false)
                    service = ResolveInstance(ics, scope);

                return service;
            }

            return null;
        }


        private object? ResolveInstance(InstanceCallsite callsite, ServiceScope scope)
        {
            var result = Factory.Create(callsite, scope);

            if (result == null)
                return null;

            if (callsite.Lifetime != ServiceLifetimes.Transient)
                scope.AddService(callsite, result);

            foreach (var middleware in callsite.Root?.ActivatedMiddlewares ?? Enumerable.Empty<ActivatedMiddleware>())
                middleware.Invoke(result, scope);

            return result;
        }


        private static object? ResolveEnumerable(EnumerableCallsite callsite, ServiceScope scope)
        {
            var array = Array.CreateInstance(callsite.GenericType, callsite.Items.Length);

            for (int i = 0; i < array.Length; i++)
            {
                var service = scope.GetServiceByCallsite(callsite.Items[i]);
                array.SetValue(service, i);
            }

            return array;
        }
    }


    class ResolveContext
    {
        public required ServiceScope Scope { get; init; }

        public required ServiceScope Root { get; init; }

        public required ServiceCallsite Callsite { get; init; }
    }
}
