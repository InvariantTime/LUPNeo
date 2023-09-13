using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
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
		private readonly HashSet<IRegistrationData> datas;

		public LUPServiceCollection()
		{
			datas = new();

			//Init default services
			this.RegisterType(typeof(Logger<>)).As(typeof(ILogger<>));
			this.RegisterType<LoopPipeline>().As<ILoopPipeline>();
		}


		public void Add(IRegistrationData data)
		{
			if (data == null)
				throw new ArgumentNullException(nameof(data));

			datas.Add(data);
		}


        public IEnumerator<IRegistrationData> GetEnumerator()
        {
			return datas.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
			return GetEnumerator();
        }
    }
}
