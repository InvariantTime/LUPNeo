namespace LUP.DependencyInjection.Resolve
{
    public class EnumerableCallsite : ServiceCallsite
    {
        public required Type GenericType { get; init; }

        public required ServiceCallsite[] Items { get; init; }
    }
}
