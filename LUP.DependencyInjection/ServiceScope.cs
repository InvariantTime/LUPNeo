using LUP.DependencyInjection.CallSites;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    class ServiceScope : IServiceScope, IServicesProvider, IAsyncDisposable
    {
        private readonly ServiceProvider root;

        public IServicesProvider Services => this;

        public ConcurrentDictionary<InstanceCallsite, object?> ActivatedServices { get; }

        public ServiceScope(ServiceProvider root)
        {
            ActivatedServices = new();
            this.root = root;
        }


        public object? GetService(Type serviceType) => root.GetService(serviceType, this);


        public IServiceScope CreateScope() => root.CreateScope();


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public async ValueTask DisposeAsync()
        {

        }
    }
}
