namespace LUP.DependencyInjection.Resolve
{
    public abstract class ServiceCallsite
    {
        public required Type[] Aliases { get; init; }

        public required ServiceDescriptor? Root { get; init; }
    }
}
