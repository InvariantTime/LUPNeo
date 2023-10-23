namespace LUP.DependencyInjection
{
    public class ServiceDescriptor
    {
        public Type[] Types { get; init; } = Array.Empty<Type>();

        public ServiceLifetimes Lifetime { get; init; }

        public IEnumerable<ActivatedMiddleware> ActivatedMiddlewares { get; init; } = Enumerable.Empty<ActivatedMiddleware>();

        //TODO: NonLazy
        // public bool NonLazy { get; init; }
    }

    public class TypedServiceDescriptor : ServiceDescriptor
    {
        public required Type Implementation { get; init; }
    }

    public class InstancedServiceDescriptor : ServiceDescriptor
    {
        public object? Instance { get; init; }

        public InstancedServiceDescriptor()
        {
            Lifetime = ServiceLifetimes.Singleton;
        }
    }

    public class FactoryServiceDescriptor : ServiceDescriptor
    {
        public required Func<IServiceScope, object?> Factory { get; init; }
    }
}
