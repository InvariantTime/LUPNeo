using LUP.DependencyInjection.Builder;

namespace LUP.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IRegistrationBuilder<TImpl, ImplementRegistrationData<TImpl>>
            RegisterType<TImpl>(this IServiceCollection collection)
        {
            return RegistrationFactory.CreateWithImplementation<TImpl>(collection);
        }


        public static IRegistrationBuilder<object, ImplementRegistrationData>
            RegisterType(this IServiceCollection collection, Type type)
        {
            return RegistrationFactory.CreateWithImplementation(collection, type);
        }


        public static IRegistrationBuilder<TImpl, FactoryRegistrationData<TImpl>>
            RegisterFactory<TImpl>(this IServiceCollection collection, Func<IServiceScope, TImpl> factory)
        {
            return RegistrationFactory.CreateWithFactory(collection, factory);
        }


        public static IRegistrationBuilder<TIns, InstanceRegistrationData<TIns>>
            RegisterInstance<TIns>(this IServiceCollection collection, TIns instance)
        {
            return RegistrationFactory.CreateWithInstance(collection, instance);
        }


        public static IServiceProvider BuildProvider(this IServiceCollection collection)
        {
            return new ServiceProvider(collection);
        }


        internal static IEnumerable<ServiceDescriptor> GetDescriptors(this IServiceCollection collection)
        {
            return collection.Select(x => x.Build());
        }
    }
}
