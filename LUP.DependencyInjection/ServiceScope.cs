using LUP.DependencyInjection.Resolve;
using System.Collections.Concurrent;

namespace LUP.DependencyInjection
{
    class ServiceScope : IServiceScope, IServiceProvider
    {
        private readonly ServiceProvider root;
        private readonly ConcurrentDictionary<ServiceCallsite, object?> activatedServices;
        private readonly ConcurrentStack<object> disposables;

        private bool isDisposed;

        public IServiceProvider Services => this;

        public ServiceScope(ServiceProvider provider)
        {
            root = provider;

            activatedServices = new();
            disposables = new();
        }


        public bool TryGetService(ServiceCallsite callsite, out object? service)
        {
            var result = activatedServices.TryGetValue(callsite, out service);
            return result;
        }


        public void AddService(ServiceCallsite callsite, object? service)
        {
            activatedServices.TryAdd(callsite, service);

            if (service != null)
                disposables.Push(service);
        }


        public object? GetService(Type serviceType)
        {
            if (isDisposed == true)
                throw new ObjectDisposedException(nameof(ServiceScope));

            return root.GetService(serviceType, this);
        }

        internal object? GetServiceByCallsite(ServiceCallsite callsite)
        {
            if (isDisposed == true)
                throw new ObjectDisposedException(nameof(ServiceScope));

            return root.GetServiceByCallsite(callsite, this);
        }


        public void Dispose()
        {
            if (isDisposed == true)
                throw new ObjectDisposedException(nameof(ServiceScope));

            foreach (var disposable in disposables)
            {
                if (disposable is IDisposable d)
                    d.Dispose();

                else if (disposable is IAsyncDisposable ad)
                    throw new Exception("Object cannot be disposed async");
            }

            disposables.Clear();
            isDisposed = true;
        }


        public async ValueTask DisposeAsync()
        {
            if (isDisposed == true)
                throw new ObjectDisposedException(nameof(ServiceScope));

            foreach (var disposable in disposables)
            {
                if (disposable is IAsyncDisposable ad)
                    await ad.DisposeAsync();

                else if (disposable is IDisposable d)
                    d.Dispose();
            }

            disposables.Clear();
            isDisposed = true;
        }
    }
}
