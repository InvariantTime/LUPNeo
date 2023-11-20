using LUP.Parsing.Parsers;

namespace LUP.Parsing.AST.Expressions
{
    class EqualReduceExpression : IReduceExpression
    {
        public IReduceExpression Right { get; }

        public EqualReduceExpression(IReduceExpression right)
        {
            Right = right;
        }


        public IReduceExpression? Handle(ReduceContext context)
        {
            var reduce = Right.Handle(context);

            if (reduce is not IReduceValue expr)
                throw new InvalidOperationException($"Invalid semantic value: {reduce}");
         
            var ast = expr.ToAST(context);

            context.Pool.AddExpression(context.ResultToken, ast);

            return EmptyReduceExpression.Instance;
        }
    }
}
