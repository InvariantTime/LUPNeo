using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class RuleBodyExpr : IParserExpression
    {
        private readonly List<RuleBodySegmentExpr> segments;

        public IReadOnlyCollection<RuleBodySegmentExpr> Segments { get; }

        public RuleBodyExpr(RuleBodySegmentExpr first)
        {
            segments = new()
            {
                first
            };

            Segments = new ReadOnlyCollection<RuleBodySegmentExpr>(segments);
        }


        public void Add(RuleBodySegmentExpr segment)
        {
            segments.Add(segment);
        }


        public static IParserExpression BuildBody1(RuleBodySegmentExpr segment)
        {
            return new RuleBodyExpr(segment);
        }


        public static IParserExpression BuildBody2(RuleBodyExpr body, RuleBodySegmentExpr segment)
        {
            body.Add(segment);
            return body;
        }
    }
}
