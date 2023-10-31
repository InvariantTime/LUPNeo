using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class RuleBodySegmentExpr : IParserExpression
    {
        public RuleParamExpr? Param { get; }

        public TokensExpr? TokensExpr { get; }

        public RuleBodySegmentExpr(TokensExpr tokensExpr, RuleParamExpr? param = null)
        {
            TokensExpr = tokensExpr;
            Param = param;
        }


        public RuleBodySegmentExpr(RuleParamExpr? param)
        {
            TokensExpr = null;
            Param = param;
        }


        public static IParserExpression BuildSegment(TokensExpr tokens)
        {
            return new RuleBodySegmentExpr(tokens);
        }


        public static IParserExpression BuildSegmentParams(TokensExpr tokens, RuleParamExpr param)
        {
            return new RuleBodySegmentExpr(tokens, param);
        }


        public static IParserExpression BuildSegmentEmpty(RuleParamExpr? param)
        {
            return new RuleBodySegmentExpr(param);
        }
    }
}
