using LUP.DependencyInjection.CallSites;
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
        public static readonly ServiceProviderEngine Instance = new();

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


        internal Func<ServiceScope, object?> CreateActivator(Callsite callsite)
        {
            if (callsite is InstanceCallsite ics)
                return CreateInstanceActivator(ics);

            if (callsite is EnumerableCallsite ecs)
                return CreateEnumerableActivator(ecs);

            return _ => null;
        }


        private Func<ServiceScope, object?> CreateInstanceActivator(InstanceCallsite callsite)
        {
            if (callsite.LifeTime == LifeTimes.Transient)
                return scope => Factory.CreateService(callsite, scope);
            
            if (callsite.LifeTime == LifeTimes.Scope)
            {
                return scope =>
                {
                    var value = scope.GetOrAddService(callsite, x => Factory.CreateService(callsite, scope));
                    return value;
                };
            }

            return _ => null;
        }


        private static Func<ServiceScope, object?> CreateEnumerableActivator(EnumerableCallsite callsite)
        {
            return scope =>
            {
                var array = Array.CreateInstance(callsite.GenericAlias, callsite.Callsites.Length);

                for (int i = 0; i < array.Length; i++)
                    array.SetValue(scope.GetService(callsite.Callsites[i].Alias), i);

                return array;
            };
        }
    }
}
