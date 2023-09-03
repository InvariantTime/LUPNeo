using LUP.DependencyInjection;

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

            Assert.AreNotEqual(service1, service2.Ints, "services must be equal");
        }


        class SomeClass
        {
            public IEnumerable<int> Ints { get; }

            public SomeClass(IEnumerable<int> ints)
            {
                Ints = ints;
            }
        }
    }
}