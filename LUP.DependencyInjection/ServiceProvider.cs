using LUP.DependencyInjection.CallSites;
using LUP.DependencyInjection.Factories;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    public class ServiceProvider : IServicesProvider
    {
        private readonly ConcurrentDictionary<Type, Func<ServiceScope, object?>> activators;
        private readonly ServiceProviderEngine engine;
        private readonly ICallsiteFactory callsiteFactory;
        private readonly ServiceScope root;


        internal ServiceProvider(IEnumerable<ServiceDescriptor> descriptors)
        {
            callsiteFactory = new CallsiteFactory(descriptors);
            root = new(this);
            activators = new();
            engine = ServiceProviderEngine.Instance;
        }


        public object? GetService(Type serviceType) => GetService(serviceType, root);


        public IServiceScope CreateScope()
        {
            return new ServiceScope(this);
        }


        internal object? GetService(Type serviceType, ServiceScope scope)
        {
            var activator = activators.GetOrAdd(serviceType, CreateActivator);

            return activator.Invoke(scope);
        }


        internal object? GetService(ServiceScope scope, Callsite callsite)
        {
            var activator = CreateActivatorByCallsite(callsite);
            return activator?.Invoke(scope);
        }


        private Func<ServiceScope, object?> CreateActivator(Type serviceType)
        {
            var callsite = callsiteFactory.GetCallsite(serviceType);
            return CreateActivatorByCallsite(callsite);  
        }


        private Func<ServiceScope, object?> CreateActivatorByCallsite(Callsite? callsite)
        {
            if (callsite == null)
                return _ => null;

            if (callsite is InstanceCallsite { LifeTime: LifeTimes.Singleton } ics)
            {
                var value = engine.Factory.CreateService(ics, root);
                return _ => value;
            }

            return engine.CreateActivator(callsite);
        }


        void IDisposable.Dispose()
        {
            root.Dispose();
        }


        ValueTask IAsyncDisposable.DisposeAsync()
        {
            return root.DisposeAsync();
        }
    }
}
