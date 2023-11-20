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
    }
}
