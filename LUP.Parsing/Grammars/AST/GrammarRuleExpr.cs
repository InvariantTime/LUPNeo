using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class GrammarRuleExpr : IASTExpression
    {
        public string Result { get; }

        public bool IsStart { get; }

        public ImmutableArray<GrammarRuleSegmentExpr> Body { get; }

        public GrammarRuleExpr(string result, IEnumerable<GrammarRuleSegmentExpr> body, bool isStart = false)
        {
            Result = result;
            IsStart = isStart;
            Body = body.ToImmutableArray();
        }
    }

    class GrammarRuleSegmentExpr : IASTExpression
    {
        public static readonly GrammarRuleSegmentExpr Empty = new(Enumerable.Empty<string>()); 

        public ImmutableArray<string> Tokens { get; }

        public IGrammarParamExpr? Param { get; }

        public GrammarRuleSegmentExpr(IEnumerable<string> tokens)
        {
            Tokens = tokens.ToImmutableArray();
        }


        public GrammarRuleSegmentExpr(IEnumerable<string> tokens, IGrammarParamExpr param)
        {
            Tokens = tokens.ToImmutableArray();
            Param = param;
        }


        public GrammarRuleSegmentExpr(IGrammarParamExpr param)
        {
            Tokens = ImmutableArray<string>.Empty;
            Param = param;
        }
    }
}
