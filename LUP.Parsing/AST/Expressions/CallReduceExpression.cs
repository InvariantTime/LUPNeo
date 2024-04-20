using System.Collections.Immutable;

namespace LUP.Parsing.AST.Expressions
{
    class CallReduceExpression : IReduceExpression
    {
        public string Name { get; }

        public ImmutableArray<IReduceExpression> Args { get; }

        public string? GenericName { get; }

        public CallReduceExpression(string name, string? genericName, params IReduceExpression[] args) 
            : this(name, genericName, args.AsEnumerable())
        { }


        public CallReduceExpression(string name, string? genericName, IEnumerable<IReduceExpression> args)
        {
            Name = name;
            Args = args.ToImmutableArray();
            GenericName = genericName;
        }



        public CallReduceExpression(string name, params IReduceExpression[] args) 
            : this(name, null, args)
        { }


        public IReduceExpression Handle(ReduceContext context)
        {
            var args = GetASTExpressions(context);

            var result = context.Register.Call(Name, GenericName, args);
            return BuildReturn(result);
        }


        private IASTExpression[] GetASTExpressions(ReduceContext context)
        {
            var ast = new IASTExpression[Args.Length];

            for (int i = 0; i < Args.Length; i++)
            {
                var expr = Args[i];
                var result = expr.Handle(context);

                if (result is not IReduceValue val)
                    throw new InvalidCastException($"Unable to cast {result} to reduce value");

                ast[i] = val.ToAST(context);
            }

            return ast;
        }


        private static IReduceValue BuildReturn(IASTExpression? expression)
        {
            return expression switch
            {
                EmptyASTExpression or null => EmptyReduceExpression.Instance,

                ValueExpression<int> num => new IntReduceValue(num.Value, IntReduceValue.ValueTypes.Int),

                ValueExpression<string> str => new SimpleReduceValue<string>(str.Value),

                ValueExpression<bool> bl => new SimpleReduceValue<bool>(bl.Value),

                _ => new ASTReduceValue(expression)
            };
        }
    }
}