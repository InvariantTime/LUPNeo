using LUP.DependencyInjection.CallSites;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    class ServiceScope : IServiceScope, IServicesProvider, IAsyncDisposable
    {
        private bool isDisposed; 

        private readonly ServiceProvider root;
        private readonly ConcurrentStack<object> disposables;
        private readonly ConcurrentDictionary<InstanceCallsite, object?> activatedServices;

        public IServicesProvider Services => this;


        public ServiceScope(ServiceProvider root)
        {
            this.root = root;

            activatedServices = new();
            disposables = new();
        }


        public object? GetService(Type serviceType)
        {
            if (isDisposed == true)
                throw new InvalidOperationException("scope is already disposed");

            return root.GetService(serviceType, this);
        }


        public IServiceScope CreateScope()
        {
            if (isDisposed == true)
                throw new InvalidOperationException("scope is already disposed");

            return root.CreateScope();
        }


        public object? GetOrAddService(InstanceCallsite callsite, Func<Callsite, object?> func)
        {
            if (isDisposed == true)
                throw new InvalidOperationException("scope is already disposed");

            bool result = activatedServices.TryGetValue(callsite, out var service);

            if (result == false)
            {
                service = func.Invoke(callsite);

                if (service != null)
                    disposables.Push(service);
            }

            return service;
        }


        public void Dispose()
        {
            foreach (var dispose in disposables)
            {
                if (dispose is IDisposable d)
                {
                    d.Dispose();
                }
                else if(dispose is IAsyncDisposable ad)
                {
                    ad.DisposeAsync().GetAwaiter();
                }
            }

            disposables.Clear();
            isDisposed = true;
        }


        public async ValueTask DisposeAsync()
        {
            foreach (var dispose in disposables)
            {
                if (dispose is IAsyncDisposable ad)
                {
                    await ad.DisposeAsync();
                }
                else if(dispose is IDisposable d)
                {
                    d.Dispose();
                }
            }

            disposables.Clear();
            isDisposed = true;
        }
    }
}
