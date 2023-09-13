namespace LUP.DependencyInjection.Builder
{
    static class RegistrationFactory
    {
        public static IRegistrationBuilder<TImpl, ImplementRegistrationData<TImpl>>
            CreateWithImplementation<TImpl>(IServiceCollection collection)
        {
            var data = new ImplementRegistrationData<TImpl>();
            collection.Add(data);
            return new RegistrationBuilder<TImpl, ImplementRegistrationData<TImpl>>(data);
        }


        public static IRegistrationBuilder<TImpl, FactoryRegistrationData<TImpl>>
            CreateWithFactory<TImpl>(IServiceCollection collection, Func<IServiceScope, TImpl> func)
        {
            var data = new FactoryRegistrationData<TImpl>(func);
            collection.Add(data);

            return new RegistrationBuilder<TImpl, FactoryRegistrationData<TImpl>>(data);
        }


        public static IRegistrationBuilder<TIns, InstanceRegistrationData<TIns>>
            CreateWithInstance<TIns>(IServiceCollection collection, TIns instance)
        {
            var data = new InstanceRegistrationData<TIns>(instance);
            collection.Add(data);

            return new RegistrationBuilder<TIns, InstanceRegistrationData<TIns>>(data);
        }


        public static IRegistrationBuilder<object, ImplementRegistrationData>
            CreateWithImplementation(IServiceCollection collection, Type type)
        {
            var data = new ImplementRegistrationData(type);
            collection.Add(data);

            return new RegistrationBuilder<object, ImplementRegistrationData>(data);
        }
    }
}
