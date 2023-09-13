using LUP.DependencyInjection.Resolve;
using System.Collections.Concurrent;

namespace LUP.DependencyInjection
{
    class ServiceScope : IServiceScope, IServiceProvider
    {
        private readonly ServiceProvider root;
        private readonly ConcurrentDictionary<ServiceCallsite, object?> activatedServices;

        public IServiceProvider Services => this;

        public ServiceScope(ServiceProvider provider)
        {
            root = provider;

            activatedServices = new();
        }


        public object? GetOrAddService(ServiceCallsite callsite, Func<ServiceCallsite, object?> func)
        {
            return activatedServices.GetOrAdd(callsite, func);
        }


        public object? GetService(Type serviceType) => root.GetService(serviceType, this);


        internal object? GetServiceByCallsite(ServiceCallsite callsite) => root.GetServiceByCallsite(callsite, this);
    }
}
