using LUP.Logging;
using LUP.Rendering.ShaderLanguage.Lexers;

namespace LUP.Rendering.ShaderLanguage
{
    class ShaderLexer
    {
        public static readonly string End = "EOF";

        private readonly ILogger<ShaderCompiler> logger;

        public ShaderLexer(ILogger<ShaderCompiler> logger)
        {
            this.logger = logger;
        }


        public IEnumerable<Token> Tokenize(string source)
        {
            List<Token> tokens = new();
            string remaining = source;

            while (string.IsNullOrWhiteSpace(remaining) == false)
            {
                var match = Match(remaining);

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
                    remaining = remaining[1..];
                }
            }

            tokens.Add(new Token
            {
                Type = End
            });

            return tokens;
        }


        private static TokenMatch Match(string source)
        {
            foreach (var definition in ShaderLexerTokens.Tokens)
            {
                var match = definition.Match(source);

                if (match.IsMatch == true)
                {
                    if (definition is InvalidTokenDefinition inv)
                    {
                        throw new Exception("compile error: " + inv.Error ?? string.Empty);
                    }

                    return match;
                }
            }

            return TokenMatch.Empty;
        }
    }
}
