using LUP.DependencyInjection.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    public class ServiceProviderEngine
    {
        public static readonly ServiceProviderEngine Instance = new ServiceProviderEngine();

        public IServiceFactory Factory { get; private set; }

        private ServiceProviderEngine() 
        {
            Factory = new ExpressionBasedServiceFactory();
        }


        public void ChangeFactory(IServiceFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            Factory = factory;
        }


        internal Func<ServiceScope, object?> CreateActivator(ServiceDescriptor descriptor)
        {
            return descriptor.LifeTime switch
            {
                LifeTimes.Transient => CreateTransientActivator(descriptor),

                LifeTimes.Scope | LifeTimes.Singleton => CreateScopedActivator(descriptor),

                _ => (_ => null)
            };
        }


        private Func<ServiceScope, object?> CreateTransientActivator(ServiceDescriptor descriptor)
        {
            return scope => Factory.CreateService(descriptor, scope);
        }


        private Func<ServiceScope, object?> CreateScopedActivator(ServiceDescriptor descriptor)
        {
            return scope =>
            {
                var result = scope.ActivatedServices.GetOrAdd(descriptor, d => Factory.CreateService(d, scope));
                return result;
            };
        }
    }
}
