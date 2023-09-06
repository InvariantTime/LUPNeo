using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection.CallSites
{
    public interface ICallsiteFactory
    {
        Callsite? GetCallsite(Type serviceType);
    }


    public class CallsiteFactory : ICallsiteFactory
    {
        private readonly ImmutableList<ServiceDescriptor> descriptors;
        private readonly ConcurrentBag<Callsite> callsites;

        public CallsiteFactory(IEnumerable<ServiceDescriptor> descriptors)
        {
            callsites = new();
            this.descriptors = descriptors.ToImmutableList();
        }


        public Callsite? GetCallsite(Type serviceType)
        {
            var callsite = callsites.FirstOrDefault(x => x.Alias == serviceType);
            return CreateIfNull(callsite, serviceType, CreateByType);
        }


        private Callsite? CreateIfNull<T>(Callsite? callsite, T item, Func<T, Callsite?> func)
        {
            if (callsite == null)
            {
                callsite = func?.Invoke(item);

                if (callsite != null) 
                    callsites.Add(callsite);
            }

            return callsite;
        }


        private Callsite? CreateByType(Type serviceType)
        {
            var descriptor = descriptors.Find(x => x.Type == serviceType);

            if (descriptor == null)
            {
                if (serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    var genericAlias = serviceType.GetGenericArguments().First();

                    if (genericAlias == null)
                        throw new InvalidOperationException();

                    return CreateEnumerable(genericAlias);
                }

                descriptor = descriptors.Find(x => serviceType.GetGenericTypeDefinition() == x.Type);

                if (descriptor != null)
                    return CreateGenericDefinition(descriptor, serviceType);

                return null;
            }

            return CreateInstance(descriptor);
        }


        private EnumerableCallsite? CreateEnumerable(Type genericAlias)
        {
            var items = descriptors.Where(x => x.Type == genericAlias).Select(x => GetCallsiteByDescriptor(x)).Where(x => x is not null);

            return new EnumerableCallsite
            { 
                Alias = typeof(IEnumerable<>).MakeGenericType(genericAlias),
                Callsites = items!.ToArray()!,
                GenericAlias = genericAlias,
                Root = null
            };
        }


        private Callsite? GetCallsiteByDescriptor(ServiceDescriptor descriptor)
        {
            var callsite = callsites.FirstOrDefault(x => x.Root == descriptor && x.Alias.IsGenericTypeDefinition == false);
            return CreateIfNull(callsite, descriptor, CreateByDescriptor);
        }


        private Callsite? CreateByDescriptor(ServiceDescriptor descriptor)
        {
          //  if (descriptor.Type.IsGenericTypeDefinition == true)
           //     return CreateGenericDefinition(descriptor);

            return CreateInstance(descriptor);
        }
        
        
        private static InstanceCallsite? CreateInstance(ServiceDescriptor descriptor)
        {
            if (descriptor is SingletonServiceDescriptor ssd)
            {
                return new InstanceCallsite
                {
                    Alias = ssd.Type,
                    Implementation = ssd.Instance.GetType(),
                    LifeTime = LifeTimes.Singleton,
                    Root = ssd
                };
            }

            if (descriptor is FactoryServiceDescriptor fsd)
            {
                return new InstanceCallsite
                {
                    Alias = fsd.Type,
                    Implementation = fsd.Type,
                    LifeTime = fsd.LifeTime,
                    Func = fsd.Factory,
                    Root = fsd
                };
            }

            if (descriptor is DynamicServiceDescriptor dsd)
            {
                return new InstanceCallsite
                {
                    Alias = dsd.Type,
                    Implementation = dsd.Implementation,
                    LifeTime = dsd.LifeTime,
                    Root = dsd
                };
            }

            return null;
        }


        private static InstanceCallsite? CreateGenericDefinition(ServiceDescriptor descriptor, Type generic)
        {
            if (descriptor is DynamicServiceDescriptor dsd)
            {
                return new InstanceCallsite
                {
                    Alias = dsd.Type.MakeGenericType(generic.GenericTypeArguments),
                    Implementation = dsd.Implementation.MakeGenericType(generic.GenericTypeArguments),
                    LifeTime = dsd.LifeTime,
                    Root = dsd
                };
            }

            return null;
        }
    }
}
