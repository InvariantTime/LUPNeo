using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace LUP.DependencyInjection.Resolve
{
    public class CallsiteFactory : ICallsiteFactory
    {
        private readonly ConcurrentBag<ServiceCallsite> callsites;

        public ImmutableList<ServiceDescriptor> Descriptors { get; }

        public CallsiteFactory(IEnumerable<ServiceDescriptor> descriptors)
        {
            Descriptors = descriptors.ToImmutableList();
            callsites = new();
        }


        public ServiceCallsite? GetCallsite(Type type)
        {
            var callsite = callsites.FirstOrDefault(x => x.Aliases.Contains(type) == true);
            return CreateIfNull(callsite, CreateByType, type);
        }


        private ServiceCallsite? CreateIfNull<T>(ServiceCallsite? callSite, Func<T, ServiceCallsite?> func, T key)
        {
            if (callSite == null)
            {
                callSite = func?.Invoke(key);

                if (callSite != null)
                    callsites.Add(callSite);
            }

            return callSite;
        }


        private ServiceCallsite? CreateByType(Type type)
        {
            var descriptor = Descriptors.Find(x => x.Types.Contains(type) == true);

            if (descriptor == null)
            {
                if (type.IsGenericType == true)
                {
                    var def = type.GetGenericTypeDefinition();

                    if (def == typeof(IEnumerable<>))
                    {
                        var generic = type.GetGenericArguments().First();
                        return CreateEnumerableCallsite(generic, type);
                    }

                    descriptor = Descriptors.Find(x => x.Types.Contains(def) == true);

                    if (descriptor != null)
                    {
                        var generics = type.GetGenericArguments();
                        return CreateGeneric(descriptor, generics);
                    }
                }

                return null;
            }

            return CreateInstanceCallsite(descriptor);
        }


        private InstanceCallsite? CreateInstanceCallsite(ServiceDescriptor descriptor)
        {
            if (descriptor is InstancedServiceDescriptor isd)
            {
                return new InstanceCallsite
                {
                    Root = isd,
                    Aliases = isd.Types,
                    Value = isd.Instance,
                    Lifetime = isd.Lifetime,
                    Implementation = isd.Instance?.GetType()
                };
            }

            if (descriptor is FactoryServiceDescriptor fsd)
            {
                return new InstanceCallsite
                {
                    Root = fsd,
                    Aliases = fsd.Types,
                    Factory = fsd.Factory,
                    Lifetime = fsd.Lifetime
                };
            }

            if (descriptor is TypedServiceDescriptor tsd)
            {
                return new InstanceCallsite
                {
                    Root = tsd,
                    Aliases = tsd.Types,
                    Implementation = tsd.Implementation,
                    Lifetime = tsd.Lifetime
                };
            }

            return null;
        }


        private EnumerableCallsite? CreateEnumerableCallsite(Type generic, Type alias)
        {
            var cs = Descriptors.Where(x => x.Types.Contains(generic))
                .Select(x => CreateIfNull(callsites.FirstOrDefault(y => y.Root == x), CreateInstanceCallsite, x))
                .Where(x => x is not null);

            var enumerable = new EnumerableCallsite()
            {
                GenericType = generic,
                Aliases = new Type[] { alias },
                Items = cs!.ToArray()!,
                Root = null
            };

            return enumerable;
        }


        private static InstanceCallsite? CreateGeneric(ServiceDescriptor descriptor, Type[] generics)
        {
            if (descriptor is TypedServiceDescriptor tsd)
            {
                return new InstanceCallsite
                {
                    Aliases = tsd.Types.Select(x => x.MakeGenericType(generics)).ToArray(),
                    Root = tsd,
                    Lifetime = tsd.Lifetime,
                    Implementation = tsd.Implementation.MakeGenericType(generics)
                };
            }

            return null;
        }
    }
}
