namespace LUP.DependencyInjection.Builder
{
    public class FactoryRegistrationData<TImpl> : IRegistrationData
    {
        public IList<Type> Aliases { get; }

        public IList<ActivatedMiddleware> ActivatedMiddlewares { get; }

        public ServiceLifetimes Lifetime { get; set; }

        public Func<IServiceScope, TImpl?> Factory { get; }

        public FactoryRegistrationData(Func<IServiceScope, TImpl?> factory)
        {
            Factory = factory;

            Aliases = new List<Type>();
            ActivatedMiddlewares = new List<ActivatedMiddleware>();
        }


        public ServiceDescriptor Build()
        {
            return new FactoryServiceDescriptor()
            {
                Types = Aliases.ToArray(),
                ActivatedMiddlewares = ActivatedMiddlewares,
                Lifetime = Lifetime,
                Factory = s => Factory(s)
            };
        }
    }
}
