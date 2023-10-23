using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage
{
    static class ShaderTokens
    {
        public static readonly string None = string.Empty;

        //KeyWords
        public static readonly string Void = "VOID";

        public static readonly string If = "IF";

        public static readonly string Else = "ELSE";

        public static readonly string Namespace = "NAMESPACE";

        public static readonly string Shader = "SHADER";

        public static readonly string For = "FOR";

        public static readonly string While = "WHILE";

        public static readonly string Break = "BREAK";

        public static readonly string Return = "RETERUN";

        public static readonly string Continue = "CONTINUE";

        public static readonly string Cbuffer = "CBUFFER";

        //Brackets
        public static readonly string LBlock = "LBLOCK";

        public static readonly string RBlock = "RBLOCK";

        public static readonly string LPar = "LPAR";

        public static readonly string RPar = "RPAR";

        //Symbols
        public static readonly string Comma = "COMMA";

        public static readonly string Dot = "DOT";

        public static readonly string Slash = "SLASH";

        public static readonly string Semn = "SEMN";

        public static readonly string Colon = "COLON";

        public static readonly string Plus = "PLUS";

        public static readonly string Minus = "MINUS";

        public static readonly string Eql = "EQL";

        public static readonly string LEql = "LEQL";

        public static readonly string GEql = "GEQL";

        //Values
        public static readonly string Id = "ID";

        public static readonly string IntNumber = "INT_NUMBER";

        public static readonly string FloatNumber = "FLOAT_NUMBER";

        public static readonly string DoubleNumber = "DOUBLE_NUMBER";
        //Operators
    }
}
