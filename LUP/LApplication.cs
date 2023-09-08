using LUP.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
	public sealed class LApplication : IDisposable, IAsyncDisposable
	{
		public static LApplication? Current { get; private set; }

		public IServicesProvider Services { get; }

		public ILoopPipeline Loop { get; }

		internal LApplication(IServicesProvider services)
		{
			if (Current != null)
				throw new InvalidOperationException("Application already created");

			Services = services;
			Loop = services.GetService<ILoopPipeline>() ?? throw new InvalidOperationException("Loop was not created");
		}
		

		public void Run()
		{
			var context = new LoopContext();

			while (true)
			{
				Loop.Run(context);
			}
		}


		public void Dispose() 
		{
			Services.Dispose();
			Loop.Dispose();
		}


		public async ValueTask DisposeAsync()
		{
			await Services.DisposeAsync();
			await Loop.DisposeAsync();
		}
	}
}
