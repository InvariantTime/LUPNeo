using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Members
{
    public class ShaderMethodTable : IEnumerable<ShaderMethod>
    {
        private readonly Dictionary<string, ShaderMethod> methods;

        public ShaderMethodTable()
        {
            methods = new();
        }


        public void Push(ShaderMethod method)
        {
            var old = methods.FirstOrDefault(x => x.Key == method.Alias);
            methods.Add(method.Alias, method);
        }


        public IEnumerator<ShaderMethod> GetEnumerator()
        {
            return methods.Values.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
