using LUP.Parsing.AST;
using LUP.Parsing.Grammars.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.Compiler
{
    class RuleHandler
    {
        [GrammarCall("createGrammar")]
        public GrammarAST CreateGrammar(ListExpression<GrammarRuleExpr> rules)
        {
            return new GrammarAST(rules);
        }


        [GrammarCall("createRule")]
        public GrammarRuleExpr CreateRule(string result, ListExpression<GrammarRuleSegmentExpr> segments)
        {
            return new GrammarRuleExpr(result, segments);
        }


        [GrammarCall("createStartRule")]
        public GrammarRuleExpr CreateStartRule(string result, ListExpression<GrammarRuleSegmentExpr> segments)
        {
            return new GrammarRuleExpr(result, segments, true);
        }


        [GrammarCall("createRuleExpr")]
        public GrammarRuleSegmentExpr CreateSegment(ListExpression<string> tokens)
        {
            return new GrammarRuleSegmentExpr(tokens);
        }


        [GrammarCall("createRuleExpr")]
        public GrammarRuleSegmentExpr CreateSegment(ListExpression<string> tokens, IGrammarParamExpr param)
        {
            return new GrammarRuleSegmentExpr(tokens, param);
        }


        [GrammarCall("createRuleExpr")]
        public GrammarRuleSegmentExpr CreateSegment(IGrammarParamExpr param)
        {
            return new GrammarRuleSegmentExpr(Enumerable.Empty<string>(), param);
        }


        [GrammarCall("createRuleExpr")]
        public GrammarRuleSegmentExpr CreateSegment()
        {
            return GrammarRuleSegmentExpr.Empty;
        }
    }
}
