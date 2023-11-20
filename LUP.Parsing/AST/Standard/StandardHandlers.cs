using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST.Standard
{
    static class StandardHandlers
    {
        public static object[] Handlers =
        {
            new ListHandler(),
            new ConvertHandler()
        };


        public static KeyValuePair<string, Type>[] Types =
        {
            new("int", typeof(int)),
            new("string", typeof(string)),
            new("float", typeof(float)),
            new("double", typeof(double)),
            new("bool", typeof(bool)),
            new("uint", typeof(uint))
        };
    }

}
