namespace LUP.DependencyInjection.Resolve
{
    public class InstanceCallsite : ServiceCallsite
    {
        public required ServiceLifetimes Lifetime { get; init; }

        public object? Value { get; set; }

        public Func<IServiceScope, object?>? Factory { get; init; }

        public Type? Implementation { get; init; }
    }
}
