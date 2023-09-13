namespace LUP.DependencyInjection.Builder
{
    public interface IRegistrationBuilder<TReg, TData> where TData : IRegistrationData
    {
        TData Data { get; }

        IRegistrationBuilder<TReg, TData> As(Type type);

        IRegistrationBuilder<TReg, TData> As<TOther>();

        IRegistrationBuilder<TReg, TData> Lifetime(ServiceLifetimes lifetime);

        IRegistrationBuilder<TReg, TData> OnActivated(ActivatedMiddleware<TReg> middleware);
    }
}
