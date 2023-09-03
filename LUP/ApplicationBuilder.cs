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
<<<<<<< HEAD
		private bool isInitialized;

=======
>>>>>>> 2c7bf82a9dda440f590ac97326dcf4a76f460968
		public IServiceCollection Services { get; }

		public ApplicationBuilder()
		{
<<<<<<< HEAD
			Services = new LUPServiceCollection();
=======
			Services = ServiceCollectionBuilder.Build();
>>>>>>> 2c7bf82a9dda440f590ac97326dcf4a76f460968
		}


		public LApplication Build()
		{
<<<<<<< HEAD
			if (isInitialized == true)
				throw new InvalidOperationException("Application is already initialized");

			isInitialized = true;
			return new LApplication(Services);
=======

>>>>>>> 2c7bf82a9dda440f590ac97326dcf4a76f460968
		}
	}
}
