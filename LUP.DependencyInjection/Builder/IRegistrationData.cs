namespace LUP.DependencyInjection.Builder
{
    public interface IRegistrationData
    {
        IList<Type> Aliases { get; }

        IList<ActivatedMiddleware> ActivatedMiddlewares { get; }

        ServiceLifetimes Lifetime { get; set; }

        ServiceDescriptor Build();
    }
}
