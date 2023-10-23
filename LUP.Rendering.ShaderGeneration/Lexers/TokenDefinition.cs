using System.Text.RegularExpressions;

namespace LUP.Rendering.ShaderLanguage.Lexers
{
    class TokenDefinition
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

    class InvalidTokenDefinition : TokenDefinition
    {
        public string? Error { get; }

        public InvalidTokenDefinition(string regex, string? error = null)
            : base(string.Empty, regex)
        {
            Error = error;
        }
    }

    readonly struct TokenMatch
    {
        public static readonly TokenMatch Empty = new();

        public bool IsMatch { get; init; }

        public string Token { get; init; }

        public string? Value { get; init; }

        public string? RemainingText { get; init; }
    }

    readonly struct Token
    {
        public string Type { get; init; }

        public string? Value { get; init; }
    }
}
