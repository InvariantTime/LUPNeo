using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    //TODO: rewrite grammar reader
    static class GrammarReader
    {
        private static readonly Dictionary<RegTypes, Regex> regexes = new()
        {
            [RegTypes.None] = new(@"^(//.*|/\*(.*\n?)*\*/|\s)"),
            [RegTypes.Start] = new(@"^:"),
            [RegTypes.Next] = new(@"^\|"),
            [RegTypes.End] = new(@"^;"),
            [RegTypes.Token] = new(@"^[A-Z][A-Z_0-9]*"),
            [RegTypes.StartToken] = new(@"^\*[A-Z][A-Z_0-9]*")
        };

        public static Grammar Read(string source)
        {
            List<RawRule> rules = new();
            HashSet<string> tokens = new();
            RawRule? current = null;
            string? prev = null;
            string? startToken = null;

            string remaining = source;

            while (string.IsNullOrWhiteSpace(remaining) == false)
            {
                bool result = false;

                foreach (var regex in regexes)
                {
                    var match = regex.Value.Match(remaining);

                    if (match.Success == true)
                    {
                        switch (regex.Key)
                        {
                            case RegTypes.StartToken:

                                if (startToken != null)
                                    throw new Exception("grammar can contain one start token");

                                if (prev != null)
                                    throw new Exception("grammar syntax error");

                                if (current != null)
                                    throw new Exception("grammar syntax error");

                                startToken = match.Value[1..];
                                prev = startToken;
                                tokens.Add(startToken);
                                break;

                            case RegTypes.None: break;

                            case RegTypes.Start:

                                if (current != null)
                                    throw new Exception("grammar syntax error: expected ';' ");

                                if (prev == null)
                                    throw new Exception("grammar syntax error: expected token");

                                current = new(prev);
                                prev = null;
                                break;

                            case RegTypes.Next:
                                if (current == null)
                                    throw new Exception("grammar syntax error: expected ':'");

                                if (prev == null)
                                    throw new Exception("grammar syntax error: expected token");

                                current.Value.Tokens.Add(prev);
                                rules.Add(current.Value);
                                current = new(current.Value.Result);
                                break;

                            case RegTypes.End:
                                if (current == null)
                                    throw new Exception("grammar syntax error: expected ':'");

                                if (prev != null)
                                    current.Value.Tokens.Add(prev);

                                rules.Add(current.Value);
                                current = null;
                                prev = null;
                                break;

                            case RegTypes.Token:
                                if (prev != null)
                                    current?.Tokens.Add(prev);

                                tokens.Add(match.Value);
                                prev = match.Value;
                                break;
                        }

                        remaining = remaining[match.Length..];
                        result = true;
                    }
                }

                if (result == false)
                    throw new Exception($"unknown symbol: {remaining.First()}");
            }

            if (startToken == null)
                throw new Exception("grammar must contain start token");

            return new Grammar(rules.Select(x => new GrammarRule(x.Result, x.Tokens)), tokens, startToken);
        }

        private enum RegTypes
        {
            None,
            Token,
            Start,
            Next,
            End,
            StartToken
        }


        private readonly struct RawRule
        {
            public List<string> Tokens { get; }

            public string Result { get; }

            public RawRule(string result)
            {
                Result = result;
                Tokens = new();
            }
        }
    }
}
