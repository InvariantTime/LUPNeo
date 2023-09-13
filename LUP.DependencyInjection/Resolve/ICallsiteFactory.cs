namespace LUP.DependencyInjection.Resolve
{
    public interface ICallsiteFactory
    {
        ServiceCallsite? GetCallsite(Type type);
    }
}
