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

		public virtual required Type Type { get; init; }
	}


	public class SingletonServiceDescriptor : ServiceDescriptor
	{
		public object Instance { get; }

		public SingletonServiceDescriptor(Type type, object instance)
		{
			LifeTime = LifeTimes.Singleton;
			Type = type ?? throw new ArgumentNullException(nameof(type));
			Instance = instance ?? throw new ArgumentNullException(nameof(instance));

			if (type.IsAssignableFrom(Instance.GetType()) == false)
				throw new InvalidCastException();
		}
	}


	public class FactoryServiceDescriptor : ServiceDescriptor
	{
		public Func<object> Factory { get; }

		public FactoryServiceDescriptor(Func<object> factory, Type type, LifeTimes lifeTime)
		{
			Factory = factory;
		}
	}


	public class DynamicServiceDescriptor : ServiceDescriptor
	{
		public Type Implementation { get; }

		public DynamicServiceDescriptor()
		{

		}
	}
}
