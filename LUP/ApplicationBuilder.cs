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
		private bool isInitialized;

		public IServiceCollection Services { get; }

		public ApplicationBuilder()
		{
			Services = new LUPServiceCollection();
		}


		public LApplication Build()
		{
			if (isInitialized == true)
				throw new InvalidOperationException("Application is already initialized");

			isInitialized = true;
			return new LApplication(Services.BuildProvider());
		}
	}
}
