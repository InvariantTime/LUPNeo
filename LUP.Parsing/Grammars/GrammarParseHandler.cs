using LUP.Parsing.AST;
using LUP.Parsing.Grammars.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars
{
    class GrammarParseHandler : ASTHandler<GrammarAST>
    {
        public override GrammarAST? CreateAST()
        {
            return new GrammarAST();
        }


        protected override void RegistReduces(ReduceRegister register)
        {
            register.Register<TokenExpression, RuleBodyExpr>("rule", (name, body) => BuildRule(name, body));
            register.Register<TokenExpression, RuleBodyExpr>("ruleStart", (name, body)
                => BuildRule(name, body, true));

            register.Register<RuleBodySegmentExpr>("body1", RuleBodyExpr.BuildBody1);
            register.Register<RuleBodyExpr, RuleBodySegmentExpr>("body2", RuleBodyExpr.BuildBody2);

            register.Register<TokensExpr>("ruleExpr", RuleBodySegmentExpr.BuildSegment);
            register.Register<TokensExpr, RuleParamExpr>("ruleExprParam", RuleBodySegmentExpr.BuildSegmentParams);
            register.Register<RuleParamExpr>("ruleParamEmpty", RuleBodySegmentExpr.BuildSegmentEmpty);
            register.Register("ruleEmpty", _ => RuleBodySegmentExpr.BuildSegmentEmpty(null));

            register.Register<TokenExpression>("tokens1", TokensExpr.BuildTokens);
            register.Register<TokensExpr, TokenExpression>("tokens2", TokensExpr.BuildTokens);

            register.Register<TokenExpression, RuleParamBodyExpr>("ruleParam", RuleParamExpr.BuildParam);

            register.Register<TokenExpression>("paramBody1", RuleParamBodyExpr.BuildBody);
            register.Register<RuleParamBodyExpr, TokenExpression>("paramBody2", RuleParamBodyExpr.BuildBody);
            register.Register("emptyParamBody", _ => RuleParamBodyExpr.Empty);
        }


        private IParserExpression? BuildRule(TokenExpression name, RuleBodyExpr body, bool isStart = false)
        {
            if (name.Token.Value == null)
                throw new InvalidOperationException("Unable to get token id value");

            AST.AddRule(new GrammarRuleExpr(name.Token.Value, body, isStart));
            return null;
        }
    }
}
