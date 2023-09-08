using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public interface IOption<T>
    {
        T Accessor { get; }
    }

    public class Option<T> : IOption<T>
    {
        public T Accessor { get; }

        public Option(T Accessor)
        {
            this.Accessor = Accessor;
        }
    }
}
