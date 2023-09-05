using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
        private readonly ConcurrentDictionary<Type, Callsite?> callsites;

        public CallsiteFactory(IEnumerable<ServiceDescriptor> descriptors)
        {
            callsites = new();
            this.descriptors = descriptors.ToImmutableList();
        }


        public Callsite? GetCallsite(Type serviceType)
        {
            return callsites.GetOrAdd(serviceType, TryBuildCallSite);
        }


        private Callsite? TryBuildCallSite(Type type)
        {
            var descriptor = descriptors.Find(x => x.Type == type);

            if (type.IsGenericType == true)
            {
                if (typeof(IEnumerable<>) == type.GetGenericTypeDefinition())
                {
                    if (descriptor == null)
                        return BuildEnumerableCallsite(type);
                }

                if (TryFindDefinitionFor(type, out var res) == true)
                {
                    return BuildGenericCallsite(type, res!);
                }
            }

            return BuildInstanceCallsite(descriptor);
        }


        private Callsite? BuildInstanceCallsite(ServiceDescriptor? descriptor)
        {
            if (descriptor == null)
                return null;

            if (descriptor is SingletonServiceDescriptor ssd)
            {
                return new InstanceCallsite
                {
                    Alias = ssd.Type,
                    Implementation = ssd.Instance.GetType(),
                    LifeTime = LifeTimes.Singleton,
                    Value = ssd.Instance
                };
            }

            if (descriptor is FactoryServiceDescriptor fsd)
            {
                return new InstanceCallsite
                {
                    Alias = fsd.Type,
                    Implementation = fsd.Type,
                    LifeTime = fsd.LifeTime,
                    Func = fsd.Factory
                };
            }

            if (descriptor is DynamicServiceDescriptor dsd)
            {
                return new InstanceCallsite
                {
                    Alias = dsd.Type,
                    Implementation = dsd.Implementation,
                    LifeTime = dsd.LifeTime
                };
            }

            return null;
        }


        private EnumerableCallsite? BuildEnumerableCallsite(Type type)
        {
            var genericAlias = type.GetGenericArguments().First();

            if (genericAlias == null)
                throw new InvalidOperationException();

            var items = descriptors.Where(x => x.Type == genericAlias).Select(GetCallsiteByDescriptor);

            return new EnumerableCallsite
            {
                Alias = type,
                GenericAlias = genericAlias,
                Callsites = items!.ToArray()!
            };
        }


        private InstanceCallsite? BuildGenericCallsite(Type generic, ServiceDescriptor descriptor)
        {
            if (descriptor is DynamicServiceDescriptor dsd)
            {
                return new InstanceCallsite
                { 
                    Alias = dsd.Type,
                    LifeTime = dsd.LifeTime,
                    Implementation = dsd.Implementation.MakeGenericType(generic.GetGenericArguments())
                };
            }

            return null;
        }


        private Callsite? GetCallsiteByDescriptor(ServiceDescriptor descriptor)
        {
            return GetCallsite(descriptor.Type);
        }


        private bool TryFindDefinitionFor(Type type, out ServiceDescriptor? result)
        {
            result = null;

            if (type.IsGenericType == false)
                return false;

            result = descriptors.Find(x => x.Type == type.GetGenericTypeDefinition());
            return result != null;
        }
    }
}
