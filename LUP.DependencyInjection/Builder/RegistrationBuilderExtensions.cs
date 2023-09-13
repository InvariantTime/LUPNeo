namespace LUP.DependencyInjection.Builder
{
    public static class RegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TReg, TData> AsSingleton<TReg, TData>(this IRegistrationBuilder<TReg, TData> reg)
            where TData : IRegistrationData
        {
            reg.Lifetime(ServiceLifetimes.Singleton);
            return reg;
        }


        public static IRegistrationBuilder<TReg, TData> AsScoped<TReg, TData>(this IRegistrationBuilder<TReg, TData> reg)
           where TData : IRegistrationData
        {
            reg.Lifetime(ServiceLifetimes.Scoped);
            return reg;
        }


        public static IRegistrationBuilder<TReg, TData> AsTransient<TReg, TData>(this IRegistrationBuilder<TReg, TData> reg)
           where TData : IRegistrationData
        {
            reg.Lifetime(ServiceLifetimes.Transient);
            return reg;
        }


        public static IRegistrationBuilder<TReg, TData> AsSelf<TReg, TData>(this IRegistrationBuilder<TReg, TData> reg)
            where TData : IRegistrationData
        {
            reg.As<TReg>();
            return reg;
        }
    }
}
