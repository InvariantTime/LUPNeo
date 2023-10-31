using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    public class TokenExpression : IParserExpression
    {
        public KeyToken KeyToken { get; }

        public Token Token => KeyToken.Token;

        public TokenExpression(KeyToken token)
        {
            KeyToken = token;
        }
    }
}
