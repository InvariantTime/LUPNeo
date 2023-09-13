using LUP.DependencyInjection.Resolve;

namespace LUP.DependencyInjection.Factories
{
    public interface IServiceFactory
    {
        object? Create(InstanceCallsite activator, IServiceScope scope);
    }
}
