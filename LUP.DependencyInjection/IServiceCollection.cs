using LUP.DependencyInjection.Builder;

namespace LUP.DependencyInjection
{
    public interface IServiceCollection : IEnumerable<IRegistrationData>
    {
        void Add(IRegistrationData data);
    }
}
