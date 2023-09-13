namespace LUP.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static T? GetService<T>(this IServiceProvider provider)
        {
            return (T?)provider.GetService(typeof(T));
        }


        public static IServiceScope CreateScope(this IServiceProvider provider)
        {
            var factory = provider.GetService<IScopeFactory>()
                ?? throw new InvalidOperationException();

            return factory.CreateScope();
        }
    }
}
