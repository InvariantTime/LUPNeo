using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class GrammarAST
    {
        private readonly List<GrammarRuleExpr> rules;

        public GrammarAST()
        {
            rules = new();
        }


        public void AddRule(GrammarRuleExpr rule)
        {
            if (rule == null)
                throw new ArgumentNullException(nameof(rule));

            rules.Add(rule);
        }


        public Grammar CreateGrammar()
        {
            var start = rules.FindAll(x => x.IsStart == true);

            if (start.Count > 1)
                throw new InvalidOperationException("Start token must be single");

            if (start.Count == 0)
                throw new InvalidOperationException("Grammar must contain start token");

            var rs = GenerateRules();
            var tokens = GenerateTokens(rs);

            return new Grammar(rs, tokens, start.First().Result);
        }


        private IEnumerable<GrammarRule> GenerateRules()
        {
            foreach (var r in rules)
            {
                foreach (var s in r.Body.Segments)
                {
                    var rule = new GrammarRule(r.Result, s.TokensExpr?.Tokens ?? Enumerable.Empty<string>());

                    if (s.Param != null)
                        rule.SetParam(new ReduceParam(s.Param.Name, s.Param.Body.Indices));

                    yield return rule;
                }
            }
        }


        private static IEnumerable<string> GenerateTokens(IEnumerable<GrammarRule> rules)
        {
            HashSet<string> tokens = new();

            foreach (var rule in rules)
            {
                tokens.Add(rule.Result);

                foreach (var t in rule.Tokens)
                    tokens.Add(t);
            }

            return tokens;
        }
    }
}
