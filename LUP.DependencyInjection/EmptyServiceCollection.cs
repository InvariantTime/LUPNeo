using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.DependencyInjection
{
    public class EmptyServiceCollection : IServiceCollection
    {
        private readonly HashSet<ServiceDescriptor> descriptors = new();

        public void Add(ServiceDescriptor descriptor)
        {
            if (descriptor == null)
                throw new ArgumentNullException(nameof(descriptor));

            descriptors.Add(descriptor);
        }


        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            return descriptors.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return descriptors.GetEnumerator();
        }
    }
}
