using LUP.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DependencyInjectionTests
{
    [TestClass]
    public class ServiceProviderTests
    {
        [TestMethod]
        public void Scoped_Services_Equal_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddScoped<IEnumerable<int>, List<int>>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = scope.Services.GetService(typeof(IEnumerable<int>));

            Assert.AreEqual(service1, service2, "services must be equal");
        }


        [TestMethod]
        public void Transient_Services_Non_Equal_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddTransient<IEnumerable<int>, List<int>>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = scope.Services.GetService(typeof(IEnumerable<int>));

            Assert.AreNotEqual(service1, service2, "services cannot be equal");
        }


        [TestMethod]
        public void Singleton_Services_Equal_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddSingleton<IEnumerable<int>, List<int>>()
                .BuildProvider();

            var service1 = provider.GetService(typeof(IEnumerable<int>));
            var service2 = provider.GetService(typeof(IEnumerable<int>));

            Assert.AreEqual(service1, service2, "services must be equal");
        }


        [TestMethod]
        public void Assemble_Services_Test1()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddScoped<IEnumerable<int>, List<int>>()
                .AddScoped<SomeClass, SomeClass>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = (SomeClass)scope.Services.GetService(typeof(SomeClass))!;

            Assert.AreEqual(service1, service2.Ints, "services must be equal");
        }


        [TestMethod]
        public void Assemble_Services_Test2()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddTransient<IEnumerable<int>, List<int>>()
                .AddScoped<SomeClass, SomeClass>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = (SomeClass)scope.Services.GetService(typeof(SomeClass))!;

            Assert.AreNotEqual(service1, service2.Ints, "services cannot be equal");
        }


        [TestMethod]
        public void Enumerable_Services_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddScoped<SomeScene, SomeScene>()
                .AddScoped<IService, Service1>()
                .AddScoped<IService, Service2>()
                .AddScoped<IService, Service3>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service2 = scope.Services.GetService<SomeScene>()!;

            int count = 3;

            Assert.AreEqual(service2.Classes.Count(), count);
        }


        [TestMethod]
        public void Generic_Service_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddScoped<SomeGeneric<IService>, SomeGeneric<IService>>()
                .AddSingleton<IService, Service1>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = provider.GetService<IService>();
            var service2 = scope.GetService<SomeGeneric<IService>>();

            Assert.AreEqual(service1, service2!.Generic);
        }


        [TestMethod]
        public void Open_Generic_Service_Test()
        {
            EmptyServiceCollection collection = new();
            var provider = collection.AddScoped(typeof(IGenericService<>), typeof(GenericService<>))
                .AddScoped<SomeClassDependGeneric, SomeClassDependGeneric>()
                .AddScoped<IService, Service1>()
                .BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.GetService<IService>();
            var service2 = scope.GetService<SomeClassDependGeneric>();

            Assert.AreEqual(service1, service2!.Generic.Generic);
        }


        class SomeClass
        {
            public IEnumerable<int> Ints { get; }

            public SomeClass(IEnumerable<int> ints)
            {
                Ints = ints;
            }
        }

        class SomeScene
        {
            public IEnumerable<IService> Classes { get; }

            public SomeScene(IEnumerable<IService> classes)
            {
                Classes = classes;
            }
        }

        class SomeGeneric<T>
        {
            public T Generic { get; }

            public SomeGeneric(T generic)
            {
                Generic = generic;
            }
        }


        class SomeClassDependGeneric
        {
            public IGenericService<IService> Generic { get; }

            public SomeClassDependGeneric(IGenericService<IService> generic)
            {
                Generic = generic;
            }
        }


        interface IService { }

        interface IGenericService<T> 
        {
            T Generic { get; }
        }

        class GenericService<T> : IGenericService<T>
        {
            public T Generic { get; }

            public GenericService(T generic)
            {
                Generic = generic;
            }
        }

        class Service1 : IService { }

        class Service2 : IService { }

        class Service3 : IService { }
    }
}