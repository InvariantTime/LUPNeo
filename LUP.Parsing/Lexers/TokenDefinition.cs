using System.Text.RegularExpressions;

namespace LUP.Parsing.Lexers
{
    public class TokenDefinition
    {
        private readonly Regex regex;
        private readonly string token;
        private readonly uint index;

        public TokenDefinition(string token, string regexPattern, uint index = 0)
        {
            this.token = token ?? throw new ArgumentNullException(token);
            this.index = index;

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

                string value = index == 0 ? match.Value 
                    : match.Groups[(int)index].Value;

                return new TokenMatch
                {
                    IsMatch = true,
                    Value = value,
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
