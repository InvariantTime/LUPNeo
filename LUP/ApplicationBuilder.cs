using LUP.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
	public class ApplicationBuilder : IApplicationBuilder
	{
		public IServiceCollection Services { get; }

		public ApplicationBuilder()
		{
			Services = ServiceCollectionBuilder.Build();
		}


		public LApplication Build()
		{

		}
	}
}
