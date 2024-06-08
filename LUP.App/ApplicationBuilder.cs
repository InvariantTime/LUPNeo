using LUP.DependencyInjection;

namespace LUP.App
{
    public class ApplicationBuilder
    {
        public IServiceCollection Services { get; }

        public ApplicationBuilder()
        {
            Services = new LUPServiceCollection();
        }


        public IApplication Build()
        {
            var services = Services.BuildProvider();

            return new Application(services);
        }
    }
}