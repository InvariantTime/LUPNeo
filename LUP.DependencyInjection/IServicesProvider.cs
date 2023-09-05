using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
	public interface IServicesProvider : IDisposable, IAsyncDisposable
	{
		IServiceScope CreateScope();

		object? GetService(Type type);
	}
}
