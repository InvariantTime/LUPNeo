using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
	public abstract class ServiceDescriptor
	{
		public LifeTimes LifeTime { get; init; }

		public Type Type { get; init; }

		public ServiceDescriptor(LifeTimes lifeTime, Type type)
		{
			LifeTime = lifeTime;
			Type = type ?? throw new ArgumentNullException(nameof(type));
		}
	}


	public class SingletonServiceDescriptor : ServiceDescriptor
	{
		public object Instance { get; }

		public SingletonServiceDescriptor(Type type, object instance) : base(LifeTimes.Singleton, type)
		{
			Instance = instance ?? throw new ArgumentNullException(nameof(instance));

			if (type.IsAssignableFrom(Instance.GetType()) == false)
				throw new InvalidCastException();
		}
	}


	public class FactoryServiceDescriptor : ServiceDescriptor
	{
		public Func<IServiceScope, object> Factory { get; }

<<<<<<< HEAD
		public FactoryServiceDescriptor(Func<IServiceScope, object> factory, Type type, LifeTimes lifeTime) : base(lifeTime, type)
=======
		public FactoryServiceDescriptor(Func<object> factory, Type type, LifeTimes lifeTime) : base(lifeTime, type)
>>>>>>> 2c7bf82a9dda440f590ac97326dcf4a76f460968
		{
			Factory = factory;
		}
	}


	public class DynamicServiceDescriptor : ServiceDescriptor
	{
		public Type Implementation { get; }

		public DynamicServiceDescriptor(LifeTimes lifeTime, Type type, Type implementation) : base(lifeTime, type)
		{	
			Implementation = implementation ?? throw new ArgumentNullException(nameof(implementation));
		}
	}
}