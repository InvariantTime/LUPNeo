using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GrammarCallAttribute : Attribute
    {
        public string Name { get; } = string.Empty;

        public GrammarCallAttribute()
        {
        }


        public GrammarCallAttribute(string name)
        {
            Name = name;
        }
    }
}
