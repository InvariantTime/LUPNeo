using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST.Standard
{
    class ConvertHandler
    {
        [GrammarCall("toInt")]
        public int ToInt(string str)
        {
            bool result = int.TryParse(str, out int value);

            if (result == false)
                return -1;

            return value;
        }


        [GrammarCall("toBool")]
        public bool ToBool(string str)
        {
            return str switch
            {
                "true" => true,
                "false" => false,
                _ => throw new ArgumentException($"Unable to cast {str} to bool")
            };
        }
    }
}
