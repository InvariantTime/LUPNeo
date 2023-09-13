using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;

namespace DependencyInjectionTests
{
    [TestClass]
    public class ServiceProviderTests
    {
        [TestMethod]
        public void Scoped_Services_Equal_Test()
        {
            ServiceCollection collection = new();
            collection.RegisterType<List<int>>().As<IEnumerable<int>>().AsScoped();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = scope.Services.GetService(typeof(IEnumerable<int>));

            Assert.AreEqual(service1, service2, "services must be equal");
        }


        [TestMethod]
        public void Transient_Services_Non_Equal_Test()
        {
            ServiceCollection collection = new();
            collection.RegisterType<List<int>>().As<IEnumerable<int>>().AsTransient();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = scope.Services.GetService(typeof(IEnumerable<int>));

            Assert.AreNotEqual(service1, service2, "services cannot be equal");
        }


        [TestMethod]
        public void Singleton_Services_Equal_Test()
        {
            ServiceCollection collection = new();
            collection.RegisterType<List<int>>().As<IEnumerable<int>>().AsSingleton();
            var provider = collection.BuildProvider();

            var service1 = provider.GetService(typeof(IEnumerable<int>));
            var service2 = provider.GetService(typeof(IEnumerable<int>));

            Assert.AreEqual(service1, service2, "services must be equal");
        }


        [TestMethod]
        public void Assemble_Services_Test1()
        {
            ServiceCollection collection = new();
            collection.RegisterType<List<int>>().As<IEnumerable<int>>().AsSingleton();
            collection.RegisterType<SomeClass>().AsSelf().AsScoped();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = (SomeClass)scope.Services.GetService(typeof(SomeClass))!;

            Assert.AreEqual(service1, service2.Ints, "services must be equal");
        }


        [TestMethod]
        public void Assemble_Services_Test2()
        {
            ServiceCollection collection = new();
            collection.RegisterType<List<int>>().As<IEnumerable<int>>().AsTransient();
            collection.RegisterType<SomeClass>().AsSelf().AsScoped();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService(typeof(IEnumerable<int>));
            var service2 = (SomeClass)scope.Services.GetService(typeof(SomeClass))!;

            Assert.AreNotEqual(service1, service2.Ints, "services cannot be equal");
        }


        [TestMethod]
        public void Enumerable_Services_Test()
        {
            ServiceCollection collection = new();
            collection.RegisterType<SomeScene>().AsSelf().AsScoped();
            collection.RegisterType<Service1>().As<IService>().AsScoped();
            collection.RegisterType<Service2>().As<IService>().AsScoped();
            collection.RegisterType<Service3>().As<IService>().AsScoped();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service2 = scope.Services.GetService<SomeScene>()!;

            int count = 3;

            Assert.AreEqual(service2.Classes.Count(), count);
            Assert.AreNotEqual(service2.Classes.ElementAt(0), service2.Classes.ElementAt(1));
        }


        [TestMethod]
        public void Open_Generic_Service_Test()
        {
            ServiceCollection collection = new();
            collection.RegisterType(typeof(GenericService<>)).As(typeof(IGenericService<>)).AsScoped();
            collection.RegisterType<SomeClassDependGeneric>().AsSelf().AsScoped();
            collection.RegisterType<Service1>().As<IService>().AsScoped();
            var provider = collection.BuildProvider();

            var scope = provider.CreateScope();

            var service1 = scope.Services.GetService<IService>();
            var service2 = scope.Services.GetService<SomeClassDependGeneric>();

            Assert.AreEqual(service1, service2!.Generic.Generic);
        }


        [TestMethod]
        public void OnActivated_Service_Test()
        {
            string testString = "test";

            var collection = new ServiceCollection();
            collection.RegisterType<Service1>().As<IService>().OnActivated(x => testString = "test 2").AsSingleton();
            var porvider = collection.BuildProvider();

            string testString2 = "test 2";

            var service = porvider.GetService<IService>();

            Assert.AreEqual(testString, testString2);
        }


        [TestMethod]
        public void OnActivated_Service_Test2()
        {
            var collection = new ServiceCollection();
            collection.RegisterType<Service4>().AsSelf().OnActivated(x => x.Instance.Some = 25).AsTransient();
            var provider = collection.BuildProvider();

            int some = 25;

            var service1 = provider.GetService<Service4>();
            var service2 = provider.GetService<Service4>();

            Assert.AreEqual(service1!.Some, some);
            Assert.AreEqual(service2!.Some, some);
            Assert.AreNotEqual(service1, service2);
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

        class Service4 : IService
        {
            public int Some { get; set; }
        }
    }
}