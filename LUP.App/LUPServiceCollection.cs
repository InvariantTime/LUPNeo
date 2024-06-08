using LUP.DependencyInjection;
using LUP.DependencyInjection.Builder;
using LUP.Logging;
using LUP.Utils;
using System.Collections;

namespace LUP
{
    sealed class LUPServiceCollection : IServiceCollection
    {
        private readonly HashSet<IRegistrationData> datas;

        public LUPServiceCollection()
        {
            datas = new();

            //Init default services
            this.RegisterType(typeof(Logger<>)).As(typeof(ILogger<>)).AsSingleton();
            this.RegisterType<LoopPipeline>().As<ILoopPipeline>();
            this.RegisterType(typeof(Option<>)).As(typeof(IOption<>)).As(typeof(Option<>));
        }


        public void Add(IRegistrationData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            datas.Add(data);
        }


        public IEnumerator<IRegistrationData> GetEnumerator()
        {
            return datas.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
