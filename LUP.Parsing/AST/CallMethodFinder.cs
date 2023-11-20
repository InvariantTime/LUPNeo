using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    static class CallMethodFinder
    {
        public static IEnumerable<(MethodInfo Info, string Name)> Find(Type instance)
        {
            var callType = typeof(GrammarCallAttribute);

            var methods = instance.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => Attribute.IsDefined(x, callType) == true)
                .Select(x =>
                {
                    var attrib = (GrammarCallAttribute)Attribute.GetCustomAttribute(x, callType)!;
                    string name = string.IsNullOrEmpty(attrib.Name) == true ? x.Name : attrib.Name;

                    return (x, name);
                });

            return methods;
        }
    }
}
