using LUP.Parsing.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class GrammarAST : IASTExpression
    {
        public ImmutableArray<GrammarRuleExpr> Rules { get; }

        public GrammarAST(IEnumerable<GrammarRuleExpr> rules)
        {
            Rules = rules.ToImmutableArray();
        }


        public Grammar CreateGrammar()
        {
            var start = Rules.FirstOrDefault(x => x.IsStart == true);
            List<GrammarRule> rules = new();
            HashSet<string> tokens = new();

            if (start == null)
                throw new Exception("Grammar must have start token");

            foreach (var rule in Rules)
            {
                tokens.Add(rule.Result);

                foreach (var body in rule.Body)
                {
                    foreach (var token in body.Tokens)
                        tokens.Add(token);

                    var param = BuildReduce(body.Param);
                    rules.Add(new GrammarRule(rule.Result, param, body.Tokens));
                }
            }

            return new Grammar(rules, tokens, start.Result);
        }


        private static IReduceExpression BuildReduce(IGrammarParamExpr? expr)
        {
            if (expr == null)
                return EmptyReduceExpression.Instance;

            return expr.ToReduceExpression();
        }
    }
}
