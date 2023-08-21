using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddScoped(this IServiceCollection collection, Type type, Type implementation)
		{
			collection.Add(new DynamicServiceDescriptor(LifeTimes.Scope, type, implementation));
			return collection;
		}


		public static IServiceCollection AddTransient(this IServiceCollection collection, Type type, Type implementation)
		{
			collection.Add(new DynamicServiceDescriptor(LifeTimes.Transient, type, implementation));
			return collection;
		}


		public static IServiceCollection AddSingleton(this IServiceCollection collection, Type type, Type implementation)
		{
			collection.Add(new DynamicServiceDescriptor(LifeTimes.Singleton, type, implementation));
			return collection;
		}


		public static IServiceCollection AddScoped<TServ, TImpl>(this IServiceCollection collection) where TImpl : TServ
			=> collection.AddScoped(typeof(TServ), typeof(TImpl));


		public static IServiceCollection AddTransient<TServ, TImpl>(this IServiceCollection collection) where TImpl : TServ
			=> collection.AddTransient(typeof(TServ), typeof(TImpl));


		public static IServiceCollection AddSingleton<TServ, TImpl>(this IServiceCollection collection) where TImpl : TServ
			=> collection.AddSingleton(typeof(TServ), typeof(TImpl));

		
		public static IServiceCollection AddSingleton<TServ, TImpl>(this IServiceCollection collection, TImpl instance) where TImpl : TServ
		{
			if (instance == null)
				throw new ArgumentNullException(nameof(instance));

			collection.Add(new SingletonServiceDescriptor(typeof(TServ), instance));
			return collection;
		}
	}
}
