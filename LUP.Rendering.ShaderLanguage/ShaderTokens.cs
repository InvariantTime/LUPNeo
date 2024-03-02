using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage
{
    static class ShaderTokens
    {
        public static readonly string None = string.Empty;

        //KeyWords
        public static readonly string Namespace = "NAMESPACE";

        public static readonly string Shader = "SHADER";

        public static readonly string CBuffer = "CBUFFER";

        public static readonly string Param = "PARAM";

        public static readonly string Using = "USING";

        public static readonly string Attribute = "ATTRIB";

        public static readonly string Final = "FINAL";

        public static readonly string Static = "STATIC";

        public static readonly string If = "IF";

        public static readonly string Else = "ELSE";

        public static readonly string While = "WHILE";

        public static readonly string For = "For";

        public static readonly string Return = "RETURN";

        //Shader types
        public static readonly string Pixel = "PIXEL";

        public static readonly string Vertex = "VERTEX";

        public static readonly string Geometry = "GEOMETRY";

        public static readonly string Compute = "COMPUTE";

        public static readonly string Tessellation = "TESS";

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

        public static readonly string Equal = "EQUAL";

        public static readonly string Less = "LESS";

        public static readonly string Greater = "GRTR";

        //Values
        public static readonly string Id = "ID";

        public static readonly string IntNumber = "INT_NUMBER";

        public static readonly string FloatNumber = "FLOAT_NUMBER";

        public static readonly string DoubleNumber = "DOUBLE_NUMBER";
        //Operators
    }
}
