using LUP.DependencyInjection;

namespace LUP
{
    public class ApplicationBuilder : IApplicationBuilder
    {
        private bool isInitialized;

        public IServiceCollection Services { get; }

        public ApplicationBuilder()
        {
            Services = new LUPServiceCollection();
        }


        public LApplication Build()
        {
            if (isInitialized == true)
                throw new InvalidOperationException("Application is already initialized");

            isInitialized = true;
            return new LApplication(Services.BuildProvider());
        }
    }
}
