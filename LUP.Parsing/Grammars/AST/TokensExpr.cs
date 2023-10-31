using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class TokensExpr : IParserExpression
    {
        private readonly List<string> tokens;

        public IReadOnlyCollection<string> Tokens { get; }

        public TokensExpr(string first)
        {
            tokens = new()
            {
                first
            };

            Tokens = new ReadOnlyCollection<string>(tokens);
        }


        public void Add(string token)
        {
            tokens.Add(token);
        }


        public static IParserExpression BuildTokens(TokenExpression token)
        {
            if (token.Token.Value == null)
                throw new InvalidOperationException("Unable to get token id");

            return new TokensExpr(token.Token.Value);
        }


        public static IParserExpression BuildTokens(TokensExpr tokens, TokenExpression token)
        {
            if (token.Token.Value == null)
                throw new InvalidOperationException("unable to get token id");

            tokens.Add(token.Token.Value);
            return tokens;
        }
    }
}
