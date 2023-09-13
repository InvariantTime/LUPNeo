namespace LUP.DependencyInjection.Builder
{
    public class InstanceRegistrationData<T> : IRegistrationData
    {
        T? Instance { get; }

        public IList<Type> Aliases { get; }

        public IList<ActivatedMiddleware> ActivatedMiddlewares { get; }

        public ServiceLifetimes Lifetime { get; set; }

        public InstanceRegistrationData(T instance)
        {
            Instance = instance;
            Aliases = new List<Type>();
            ActivatedMiddlewares = new List<ActivatedMiddleware>();
        }


        public ServiceDescriptor Build()
        {
            return new InstancedServiceDescriptor()
            {
                ActivatedMiddlewares = ActivatedMiddlewares,
                Instance = Instance,
                Lifetime = ServiceLifetimes.Singleton,
                Types = Aliases.ToArray()
            };
        }
    }
}
