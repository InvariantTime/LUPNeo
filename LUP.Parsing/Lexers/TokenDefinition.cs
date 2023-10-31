using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Parsing.Lexers
{
    public class TokenDefinition
    {
        private readonly Regex regex;
        private readonly string token;

        public TokenDefinition(string token, string regexPattern)
        {
            this.token = token ?? throw new ArgumentNullException(token);
            regex = new($"^{regexPattern}");
        }


        public TokenMatch Match(string source)
        {
            var match = regex.Match(source);

            if (match.Success == true)
            {
                string remaining = string.Empty;

                if (match.Value.Length != source.Length)
                    remaining = source[match.Length..];

                return new TokenMatch
                {
                    IsMatch = true,
                    Value = match.Value,
                    Token = token,
                    RemainingText = remaining
                };
            }
            else
            {
                return TokenMatch.Empty;
            }
        }
    }

    public class InvalidTokenDefinition : TokenDefinition
    {
        public string Error { get; }

        public InvalidTokenDefinition(string regex, string error = "")
            : base(string.Empty, regex)
        {
            Error = error ?? string.Empty;
        }
    }

    public readonly struct TokenMatch
    {
        public static readonly TokenMatch Empty = new();

        public bool IsMatch { get; init; }

        public string Token { get; init; }

        public string? Value { get; init; }

        public string? RemainingText { get; init; }
    }
}
