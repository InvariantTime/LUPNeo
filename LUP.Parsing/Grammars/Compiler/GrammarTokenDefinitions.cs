using LUP.Parsing.Lexers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.Compiler
{
    static class GrammarTokenDefinitions
    {
        public static readonly TokenDefinition[] Definitions =
        {
            new TokenDefinition(GrammarTokens.Semn, @";"),
            new TokenDefinition(GrammarTokens.And, @"\|"),
            new TokenDefinition(GrammarTokens.Colon, @":"),
            new TokenDefinition(GrammarTokens.Start, @"\$"),
            new TokenDefinition(GrammarTokens.Equal, @"="),
            new TokenDefinition(GrammarTokens.LPar, @"\("),
            new TokenDefinition(GrammarTokens.RPar, @"\)"),
            new TokenDefinition(GrammarTokens.Comma, @","),
            new TokenDefinition(GrammarTokens.LGener, @"<"),
            new TokenDefinition(GrammarTokens.RGener, @">"),

            new TokenDefinition(GrammarTokens.ID, @"(true|false)[a-zA-Z_0-9]"),

            new TokenDefinition(GrammarTokens.False, @"false"),
            new TokenDefinition(GrammarTokens.True, @"true"),

            new TokenDefinition(GrammarTokens.LBlock, @"\{"),
            new TokenDefinition(GrammarTokens.RBlock, @"\}"),
            new TokenDefinition(GrammarTokens.Index, "%"),
            new TokenDefinition(GrammarTokens.Number, @"[0-9]+"),

            new TokenDefinition(GrammarTokens.None, @"\s"),
            new TokenDefinition(GrammarTokens.None, @"//.*"),
            new TokenDefinition(GrammarTokens.None, @"/\*(.*\n?)*\*/"),
            new InvalidTokenDefinition(@"/\\*(.*\\n?)*", "multiline comment must be closed"),
            
            new TokenDefinition(GrammarTokens.ID, @"[a-zA-Z_][a-zA-Z_0-9]*"),
            new TokenDefinition(GrammarTokens.String, "\"([^\n\"]*)\"", 1)
        };
    }
}
