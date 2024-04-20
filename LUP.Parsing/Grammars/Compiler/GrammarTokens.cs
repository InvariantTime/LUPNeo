using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.Compiler
{
    static class GrammarTokens
    {
        public static readonly string None = string.Empty;

        public static readonly string ID = "ID";

        public static readonly string Semn = "SEMN";

        public static readonly string And = "AND";

        public static readonly string Colon = "COLON";

        public static readonly string Start = "START";

        public static readonly string LBlock = "LBLOCK";

        public static readonly string RBlock = "RBLOCK";

        public static readonly string Index = "INDEX";

        public static readonly string Number = "NUMBER";

        public static readonly string Equal = "EQUAL";

        public static readonly string LPar = "LPAR";

        public static readonly string RPar = "RPAR";

        public static readonly string Comma = "COMMA";

        public static readonly string LGener = "LGENER";

        public static readonly string RGener = "RGENER";

        public static readonly string String = "STRING";

        public static readonly string False = "FALSE";

        public static readonly string True = "TRUE";
    }
}
