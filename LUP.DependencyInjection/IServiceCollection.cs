using System.Collections;

namespace LUP.DependencyInjection
{
	public interface IServiceCollection : IEnumerable<ServiceDescriptor>
	{
		void Add(ServiceDescriptor descriptor);
	}
}