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

                if (ics.Lifetime == ServiceLifetimes.Scoped)
                    return context.Scope.GetOrAddService(ics, _ => ResolveInstance(ics, context.Scope));

                if (ics.Lifetime == ServiceLifetimes.Singleton)
                    return context.Root.GetOrAddService(ics, _ => ResolveInstance(ics, context.Scope));
            }

            return null;
        }


        private object? ResolveInstance(InstanceCallsite callsite, IServiceScope scope)
        {
            var result = Factory.Create(callsite, scope);

            if (result == null)
                return null;

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
