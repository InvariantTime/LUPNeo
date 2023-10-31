using LUP.Parsing.Lexers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing
{
    public class Lexer
    {
        public static readonly string End = "EOF";

        private readonly ImmutableArray<TokenDefinition> definitions;

        public Lexer(IEnumerable<TokenDefinition> definitions)
        {
            this.definitions = definitions.ToImmutableArray();
        }


        public LexerResult Tokenize(string source)
        {
            List<Token> tokens = new();
            string remaining = source;

            while (string.IsNullOrWhiteSpace(remaining) == false)
            {
                var res = Match(remaining);

                if (res.Success == false)
                    return new(res.Error);

                var match = res.Match;

                if (match.IsMatch == true)
                {
                    if (match.Token != string.Empty)
                    {
                        tokens.Add(new Token
                        {
                            Value = match.Value,
                            Type = match.Token
                        });
                    }

                    remaining = match.RemainingText ?? string.Empty;
                }
                else
                {
                    return new($"Undefined symbol: {remaining.First()}");
                }
            }

            tokens.Add(Token.Empty);
            return new(tokens);
        }


        private MatchResult Match(string source)
        {
            foreach (var definition in definitions)
            {
                var match = definition.Match(source);

                if (match.IsMatch == true)
                {
                    if (definition is InvalidTokenDefinition itd)
                        return new(itd.Error);

                    return new(match);
                }
            }

            return MatchResult.Empty;
        }

        readonly struct MatchResult
        {
            public static readonly MatchResult Empty = new(TokenMatch.Empty);

            public TokenMatch Match { get; init; }

            public bool Success { get; init; }

            public string Error { get; init; }

            public MatchResult(string error)
            {
                Success = false;
                Error = error;
                Match = TokenMatch.Empty;
            }


            public MatchResult(TokenMatch match)
            {
                Error = string.Empty;
                Success = true;
                Match = match;
            }
        }
    }

    public readonly struct LexerResult
    {
        public IEnumerable<Token> Tokens { get; init; }

        public bool Success { get; init; }

        public string Error { get; init; }


        public LexerResult(params Token[] tokens) : this(tokens.AsEnumerable())
        {
        }


        public LexerResult(string error)
        {
            Success = false;
            Error = error;
            Tokens = Enumerable.Empty<Token>();
        }


        public LexerResult(IEnumerable<Token> tokens)
        {
            Success = true;
            Error = string.Empty;
            Tokens = tokens;
        }
    }
}
