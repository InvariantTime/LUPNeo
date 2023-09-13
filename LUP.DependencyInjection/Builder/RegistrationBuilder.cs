namespace LUP.DependencyInjection.Builder
{
    class RegistrationBuilder<TReg, TData> : IRegistrationBuilder<TReg, TData> where TData : IRegistrationData
    {
        public TData Data { get; }

        public RegistrationBuilder(TData data)
        {
            Data = data;
        }


        public IRegistrationBuilder<TReg, TData> As(Type type)
        {
            Data.Aliases.Add(type);
            return this;
        }


        public IRegistrationBuilder<TReg, TData> As<TOther>()
        {
            As(typeof(TOther));
            return this;
        }


        public IRegistrationBuilder<TReg, TData> Lifetime(ServiceLifetimes lifetime)
        {
            Data.Lifetime = lifetime;
            return this;
        }


        public IRegistrationBuilder<TReg, TData> OnActivated(ActivatedMiddleware<TReg> middleware)
        {
            Data.ActivatedMiddlewares.Add((instance, scope) =>
            {
                middleware.Invoke(new ActivatedContext<TReg>()
                {
                    Instance = (TReg)instance,
                    Scope = scope
                });
            });

            return this;
        }
    }
}
