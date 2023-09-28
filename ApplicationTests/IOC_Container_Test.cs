namespace ApplicationTests
{
    [TestClass]
    public class IOC_Container_Test
    {
        [TestMethod]
        public void Config_Test()
        {
            var builder = new ApplicationBuilder();
            builder.Services.Configure<Config1>(x =>
            {
                x.Test = 6;
            });

            var app = builder.Build();

            var config1 = app.Services.GetService<IOption<Config1>>();
            var config2 = app.Services.GetService<IOption<Config2>>();

            Assert.IsNotNull(config1);
            Assert.IsNotNull(config2);
        }

        [TestMethod]
        public void Cofig_Change_Settings_Test()
        {
            var builder = new ApplicationBuilder();
            builder.Services.Configure<Config1>(x =>
            {
                x.Test = 6;
            });

            var app = builder.Build();

            var config1 = app.Services.GetService<IOption<Config1>>();
            var config2 = app.Services.GetService<IOption<Config2>>();

            int test1 = 6;
            int test2 = 1;

            Assert.AreEqual(config1!.Accessor.Test, test1);
            Assert.AreEqual(config2!.Accessor.Test, test2);
        }
    }


    class Config1
    {
        public int Test { get; set; }

        public Config1()
        {
            Test = 1;
        }
    }


    class Config2
    {
        public int Test { get; set; }

        public Config2()
        {
            Test = 1;
        }
    }
}