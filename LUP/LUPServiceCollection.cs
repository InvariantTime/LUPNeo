using LUP.DependencyInjection;
using LUP.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
	sealed class LUPServiceCollection : IServiceCollection
	{
		private readonly HashSet<ServiceDescriptor> descriptors;

		public LUPServiceCollection()
		{
			descriptors = new HashSet<ServiceDescriptor>();

			//Init default services
			this.AddSingleton<ILogger, Logger>();
			this.AddSingleton<ILoggerService, ConsoleLoggerService>();
		}


		public void Add(ServiceDescriptor serviceDescriptor)
		{
			if (serviceDescriptor == null)
				throw new ArgumentNullException(nameof(serviceDescriptor));

			descriptors.Add(serviceDescriptor);
		}


        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
			return descriptors.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetEnumerator();
        }
    }
}
