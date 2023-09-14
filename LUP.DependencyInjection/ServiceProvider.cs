using LUP.DependencyInjection.Builder;
using LUP.DependencyInjection.Resolve;

namespace LUP.DependencyInjection
{
    public class ServiceProvider : IServiceProvider, IScopeFactory, IDisposable, IAsyncDisposable
    {
        private readonly ServiceProviderEngine engine;
        private readonly ICallsiteFactory callsiteFactory;

        internal ServiceScope Root { get; }

        internal ServiceProvider(IServiceCollection collection)
        {
            collection.RegisterInstance(this).As<IScopeFactory>().AsSingleton();
            var descriptors = collection.GetDescriptors();

            callsiteFactory = new CallsiteFactory(descriptors);
            engine = new ServiceProviderEngine();
            Root = new ServiceScope(this);
        }

        public object? GetService(Type serviceType) => GetService(serviceType, Root);


        public IServiceScope CreateScope()
        {
            return new ServiceScope(this);
        }


        internal object? GetService(Type serviceType, ServiceScope scope)
        {
            var callsite = callsiteFactory.GetCallsite(serviceType);
            return GetServiceByCallsite(callsite, scope);
        }


        internal object? GetServiceByCallsite(ServiceCallsite? callsite, ServiceScope scope)
        {
            if (callsite == null)
                return null;

            var context = new ResolveContext()
            {
                Callsite = callsite,
                Root = Root,
                Scope = scope
            };

            return engine.Resolve(context);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Root.Dispose();
        }


        public async ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            await Root.DisposeAsync();
        }
    }
}
