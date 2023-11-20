
namespace LUP.Parsing.AST.Expressions
{
    class ASTReduceValue : IReduceValue
    {
        public IASTExpression Expression { get; }

        public ASTReduceValue(IASTExpression expression)
        {
            Expression = expression;
        }


        public IReduceExpression? Handle(ReduceContext context)
        {
            return this;
        }


        public IASTExpression ToAST(ReduceContext context)
        {
            return Expression;
        }
    }

    class StringReduceValue : IReduceValue
    {
        public static readonly StringReduceValue Empty = new("");

        public string Value { get; }

        public StringReduceValue(string value)
        {
            Value = value;
        }


        public IReduceExpression? Handle(ReduceContext context)
        {
            return this;
        }


        public IASTExpression ToAST(ReduceContext context)
        {
            return new ValueExpression<string>(Value);
        }
    }

    class IntReduceValue : IReduceValue
    {
        public int Value { get; }

        public ValueTypes Type { get; }

        public IntReduceValue(int value, ValueTypes type)
        {
            Value = value;
            Type = type;
        }


        public IReduceExpression? Handle(ReduceContext context)
        {
            return this;
        }


        public IASTExpression ToAST(ReduceContext context)
        {
            if (Type == ValueTypes.Index)
            {
                if (Value < 0 || Value >= context.Tokens.Length)
                    throw new IndexOutOfRangeException("Index out of range tokens");

                var key = context.Tokens[Value];
                var ast = context.Pool.GetAST(key);
                return ast;
            }

            return new ValueExpression<int>(Value);
        }


        public enum ValueTypes
        {
            Int,
            Index
        }
    }
}
