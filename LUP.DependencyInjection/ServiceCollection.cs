using LUP.DependencyInjection.Builder;
using System.Collections;

namespace LUP.DependencyInjection
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<IRegistrationData> datas;

        public ServiceCollection()
        {
            datas = new();
        }


        public void Add(IRegistrationData data)
        {
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
