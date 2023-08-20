using LUP.DependencyInjection;

namespace LUP
{
	public interface IApplicationBuilder
	{
		IServiceCollection Services { get; }

		LApplication Build();
	}
}
