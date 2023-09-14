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


        public object? GetOrAddService(ServiceCallsite callsite, Func<ServiceCallsite, object?> func)
        {
            var result = activatedServices.TryGetValue(callsite, out var obj);

            if (result == false)
            {
                obj = func?.Invoke(callsite);

                if (obj != null)
                {
                    activatedServices.TryAdd(callsite, obj);
                    disposables.Push(obj);
                }
            }

            return obj;
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
