using LUP.Rendering.ShaderLanguage.Lexers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage
{
    static class ShaderLexerTokens
    {
        public static readonly TokenDefinition[] Tokens =
        {
            //key words
            new TokenDefinition(ShaderTokens.Shader, "shader"),
            new TokenDefinition(ShaderTokens.Namespace, "namespace"),
            new TokenDefinition(ShaderTokens.Void, "void"),
            new TokenDefinition(ShaderTokens.Cbuffer, "cbuffer"),
            
            //non tokens
            new TokenDefinition(ShaderTokens.None, @"//[^\n]+"),

            new TokenDefinition(ShaderTokens.None, @"/\*((.*\n?)*)\*/"),
            new InvalidTokenDefinition(@"/\*((.*\n?)*)", "multiline comments must be closed"),

            //symbols
            new TokenDefinition(ShaderTokens.LBlock, "{"),
            new TokenDefinition(ShaderTokens.RBlock, "}"),
            new TokenDefinition(ShaderTokens.LPar, @"\("),
            new TokenDefinition(ShaderTokens.RPar, @"\)"),
            new TokenDefinition(ShaderTokens.Comma, @","),
            new TokenDefinition(ShaderTokens.Dot, @"\."),
            new TokenDefinition(ShaderTokens.Slash, @"/"),
            new TokenDefinition(ShaderTokens.Semn, @";"),

            //other
            new TokenDefinition(ShaderTokens.Id, "[a-zA-Z_][a-zA-Z_0-9]*"),
          //  new TokenDefinition(TokenTypes.FLOAT_NUMBER, "")
        };
    }
}
