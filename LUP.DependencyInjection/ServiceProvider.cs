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
        private readonly ConcurrentDictionary<ServiceDescriptor, Func<ServiceScope, object?>> activators;
        private readonly ImmutableList<ServiceDescriptor> descriptors;
        private readonly ServiceProviderEngine engine;
        private readonly ServiceScope root;


        internal ServiceProvider(IEnumerable<ServiceDescriptor> descriptors)
        {
            this.descriptors = descriptors.ToImmutableList();
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
            var descriptor = descriptors.Find(x => x.Type == serviceType);

            if (descriptor == null)
                return null;

            var activator = activators.GetOrAdd(descriptor, CreateActivator);

            return activator.Invoke(scope);
        }


        private Func<ServiceScope, object?> CreateActivator(ServiceDescriptor descriptor)
        {
            if (descriptor.LifeTime == LifeTimes.Singleton)
            {
                var result = engine.Factory.CreateService(descriptor, root);
                return _ => result;
            }

            return engine.CreateActivator(descriptor);
        }


        public void Dispose()
        {

        }
    }
}
