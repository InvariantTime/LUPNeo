using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    sealed class Grammar
    {
        public ImmutableArray<GrammarRule> Rules { get; }

        public string FinalToken { get; }

        public ImmutableArray<string> Tokens { get; }

        public ImmutableArray<string> NonTerminals { get; }

        public ImmutableArray<string> Terminals { get; }

        public Grammar(IEnumerable<GrammarRule> rules, IEnumerable<string> tokens, string finalToken)
        {
            Rules = rules.ToImmutableArray();
            Tokens = tokens.ToImmutableArray();
            FinalToken = finalToken;

            Terminals = GenerateTerminals(tokens, rules).ToImmutableArray();
            NonTerminals = GenerateNonTerminals(tokens, rules).ToImmutableArray();
        }


        public bool IsNonTerminal(string token)
        {
            return NonTerminals.Contains(token) == true;
        }


        private static IEnumerable<string> GenerateTerminals(IEnumerable<string> tokens, IEnumerable<GrammarRule> rules)
        {
            return tokens.Where(x => rules.FirstOrDefault(y => y.Result == x).Result == null);
        }


        private static IEnumerable<string> GenerateNonTerminals(IEnumerable<string> tokens, IEnumerable<GrammarRule> rules)
        {
            return tokens.Where(x => rules.FirstOrDefault(y => y.Result == x).Result != null);
        }
    }

    readonly struct GrammarRule
    {
        public string Result { get; }

        public ImmutableArray<string> Tokens { get; }

        public GrammarRule(string result, IEnumerable<string> tokens)
        {
            Result = result;
            Tokens = tokens.ToImmutableArray();
        }


        public override string ToString()
        {
            StringBuilder builder = new();
            builder.Append($"{Result}:");

            foreach (var token in Tokens)
                builder.Append($" {token}");

            return builder.ToString();
        }
    }
}