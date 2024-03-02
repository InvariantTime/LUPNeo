using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation
{
    public static class GenerationTokens
    {
        private const int timeout = 5;

        //Shader tokens
        public static readonly Regex ShaderAttribute = Create("ATTRIB");

        public static readonly Regex ShaderConstant = Create("CONST");

        public static readonly Regex ShaderVariable = Create("VARIABLE");

        public static readonly Regex ShaderStruct = Create("STRUCT");

        public static readonly Regex ShaderCBuffer = Create("CBUFFER");

        public static readonly Regex ShaderParam = Create("PARAM");

        public static readonly Regex ShaderMethod = Create("METHOD");

        public static readonly Regex ShaderMain = Create("MAIN");

        private static Regex Create(string pattern)
        {
            return new($"%{pattern}%", RegexOptions.None, 
                TimeSpan.FromSeconds(timeout));
        }
    }
}
