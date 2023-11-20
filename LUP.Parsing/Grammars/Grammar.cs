using LUP.Parsing.AST.Expressions;
using System.Collections.Immutable;
using System.Text;

namespace LUP.Parsing
{
    public sealed class Grammar
    {
        public ImmutableArray<GrammarRule> Rules { get; }

        public string FinalToken { get; }

        public ImmutableArray<string> Tokens { get; }

        public ImmutableArray<string> NonTerminals { get; }

        public ImmutableArray<string> Terminals { get; }

        public Grammar(IEnumerable<GrammarRule> rules, IEnumerable<string> tokens, string finalToken)
        {
            FinalToken = finalToken;
            Rules = rules.ToImmutableArray();
            Tokens = tokens.ToImmutableArray();

            Terminals = GenerateTerminals(Tokens, Rules).ToImmutableArray();
            NonTerminals = GenerateNonTerminals(Tokens, Rules).ToImmutableArray();
        }


        public bool IsNonTerminal(string token)
        {
            return NonTerminals.Contains(token) == true;
        }


        private static IEnumerable<string> GenerateTerminals(IEnumerable<string> tokens, IEnumerable<GrammarRule> rules)
        {
            return tokens.Where(x => rules.FirstOrDefault(y => y.Result == x) == null);
        }


        private static IEnumerable<string> GenerateNonTerminals(IEnumerable<string> tokens, IEnumerable<GrammarRule> rules)
        {
            return tokens.Where(x => rules.FirstOrDefault(y => y.Result == x) != null);
        }
    }

    public sealed class GrammarRule
    {
        public string Result { get; }

        public ImmutableArray<string> Tokens { get; }

        public IReduceExpression Expression { get; private set; }

        public GrammarRule(string result, IEnumerable<string> tokens)
        {
            Result = result;
            Tokens = tokens.ToImmutableArray();
            Expression = EmptyReduceExpression.Instance;
        }


        public GrammarRule(string result, IReduceExpression? param, IEnumerable<string> tokens) : this(result, tokens)
        {
            SetParam(param);
        }


        public void SetParam(IReduceExpression? value)
        {
            if (value == null)
            {
                Expression = EmptyReduceExpression.Instance;
                return;
            }

            Expression = value;
        }

        
        public GrammarRule(string result, params string[] tokens) 
            : this(result, tokens.AsEnumerable()) { }

        
        public GrammarRule(string result, IReduceExpression? expr, params string[] tokens) : this(result, tokens)
        {
            SetParam(expr);
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