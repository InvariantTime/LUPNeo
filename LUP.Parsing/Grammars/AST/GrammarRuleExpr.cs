using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class GrammarRuleExpr : IParserExpression
    {
        public string Result { get; }

        public bool IsStart { get; }

        public RuleBodyExpr Body { get; }

        public GrammarRuleExpr(string result, RuleBodyExpr body, bool isStart = false)
        {
            Result = result;
            IsStart = isStart;
            Body = body;
        }
    }
}
