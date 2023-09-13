namespace LUP.DependencyInjection
{
    public static class ServiceScopeExtensions
    {
        public static object? GetService(this IServiceScope scope, Type type)
        {
            return scope.Services.GetService(type);
        }


        public static T? GetService<T>(this IServiceScope scope)
        {
            return scope.Services.GetService<T>();
        }


        public static IServiceScope CreateScope(this IServiceScope scope)
        {
            return scope.Services.CreateScope();
        }
    }
}
