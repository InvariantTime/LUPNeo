namespace LUP.DependencyInjection.Builder
{
    public class ImplementRegistrationData<T> : IRegistrationData
    {
        public IList<Type> Aliases { get; }

        public IList<ActivatedMiddleware> ActivatedMiddlewares { get; }

        public ServiceLifetimes Lifetime { get; set; } = ServiceLifetimes.Singleton;

        public ImplementRegistrationData()
        {
            Aliases = new List<Type>();
            ActivatedMiddlewares = new List<ActivatedMiddleware>();
        }


        public ServiceDescriptor Build()
        {
            return new TypedServiceDescriptor()
            {
                Implementation = typeof(T),
                ActivatedMiddlewares = ActivatedMiddlewares,
                Types = Aliases.ToArray(),
                Lifetime = Lifetime
            };
        }
    }

    public class ImplementRegistrationData : IRegistrationData
    {
        public IList<Type> Aliases { get; }

        public IList<ActivatedMiddleware> ActivatedMiddlewares { get; }

        public ServiceLifetimes Lifetime { get; set; } = ServiceLifetimes.Singleton;

        public Type Type { get; }

        public ImplementRegistrationData(Type type)
        {
            Type = type;

            Aliases = new List<Type>();
            ActivatedMiddlewares = new List<ActivatedMiddleware>();
        }


        public ServiceDescriptor Build()
        {
            return new TypedServiceDescriptor()
            {
                Implementation = Type,
                ActivatedMiddlewares = ActivatedMiddlewares,
                Types = Aliases.ToArray(),
                Lifetime = Lifetime
            };
        }
    }
}
