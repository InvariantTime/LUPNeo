using LUP.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
	public sealed class LApplication
	{
		public static LApplication? Current { get; private set; }

		public IServicesProvider Services { get; private set; }
		

		internal LApplication(IServiceCollection services)
		{
			Services = services.BuildProvider();
			Current = this;
		}


		public void AddUpdateModule()
		{

		}

		
		public void Run()
		{
		}
	}
}
