using LUP.Parsing.Lexers;

namespace LUP.Rendering.ShaderLanguage
{
    static class ShaderLexerTokens
    {
        public static readonly TokenDefinition[] Tokens =
        {
            //key words
            new TokenDefinition(ShaderTokens.Shader, "shader"),
            new TokenDefinition(ShaderTokens.Namespace, "namespace"),
            new TokenDefinition(ShaderTokens.Param, "param"),
            new TokenDefinition(ShaderTokens.CBuffer, "cbuffer"),
            new TokenDefinition(ShaderTokens.Using, "using"),
            new TokenDefinition(ShaderTokens.Final, "final"),
            new TokenDefinition(ShaderTokens.Static, "static"),
            new TokenDefinition(ShaderTokens.Attribute, "attrib"),
            new TokenDefinition(ShaderTokens.Return, "return"),

            //Expression and operators
            new TokenDefinition(ShaderTokens.If, "if"),
            new TokenDefinition(ShaderTokens.Else, "else"),
            new TokenDefinition(ShaderTokens.While, "while"),
            new TokenDefinition(ShaderTokens.For, "for"),


            new TokenDefinition(ShaderTokens.Pixel, "pixel"),
            new TokenDefinition(ShaderTokens.Vertex, "vertex"),
            new TokenDefinition(ShaderTokens.Geometry, "geometry"),
            new TokenDefinition(ShaderTokens.Pixel, "compute"),
            new TokenDefinition(ShaderTokens.Tessellation, "tessellation"),
            
            //non tokens
            new TokenDefinition(ShaderTokens.None, @"//[^\n]+"),
            new TokenDefinition(ShaderTokens.None, @"^\s"),

            new TokenDefinition(ShaderTokens.None, @"/\*((.*\n?)*)\*/"),
            new InvalidTokenDefinition(@"/\*((.*\n?)*)", "multiline comments must be closed"),

            //other
            new TokenDefinition(ShaderTokens.Id, "[a-zA-Z_а-яА-Я][a-zA-Z_а-яА-Я0-9]*"),
            new TokenDefinition(ShaderTokens.FloatNumber, @"[0-9]*\.[0-9]+f"),
            new TokenDefinition(ShaderTokens.IntNumber, @"[0-9]+"),

            //symbols
            new TokenDefinition(ShaderTokens.LBlock, "{"),
            new TokenDefinition(ShaderTokens.RBlock, "}"),
            new TokenDefinition(ShaderTokens.LPar, @"\("),
            new TokenDefinition(ShaderTokens.RPar, @"\)"),
            new TokenDefinition(ShaderTokens.Comma, @","),
            new TokenDefinition(ShaderTokens.Dot, @"\."),
            new TokenDefinition(ShaderTokens.Slash, @"/"),
            new TokenDefinition(ShaderTokens.Semn, @";"),
            new TokenDefinition(ShaderTokens.Colon, @":"),
            new TokenDefinition(ShaderTokens.Equal, @"\="),
            new TokenDefinition(ShaderTokens.Less, @"\<"),
            new TokenDefinition(ShaderTokens.Greater, @"\>"),
            new TokenDefinition(ShaderTokens.Plus, @"\+"),
            new TokenDefinition(ShaderTokens.Minus, @"\-"),
        };
    }
}
