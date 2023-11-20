using LUP.Parsing.AST.Expressions;
using System.Collections.Immutable;

namespace LUP.Parsing.Grammars.AST
{
    interface IGrammarParamExpr : IASTExpression
    {
        IReduceExpression ToReduceExpression();
    }

    class GrammarEqualExpr : IGrammarParamExpr
    {
        public IGrammarParamExpr Right { get; }

        public GrammarEqualExpr(IGrammarParamExpr right)
        {
            Right = right;
        }


        public IReduceExpression ToReduceExpression()
        {
            var right = Right.ToReduceExpression();
            return new EqualReduceExpression(right);
        }
    }

    class GrammarEmptyExpr : IGrammarParamExpr
    {
        public static readonly GrammarEmptyExpr Instance = new();

        private GrammarEmptyExpr()
        {
            
        }


        public IReduceExpression ToReduceExpression()
        {
            return EmptyReduceExpression.Instance;
        }
    }

    class GrammarCallExpr : IGrammarParamExpr
    {
        public string Name { get; }

        public string? Generic { get; }

        public ImmutableArray<IGrammarParamExpr> Args { get; }

        public GrammarCallExpr(string name, IEnumerable<IGrammarParamExpr> args, string? generic = null)
        {
            Name = name;
            Args = args.ToImmutableArray();
            Generic = generic;
        }

        public IReduceExpression ToReduceExpression()
        {
            var args = Args.Select(x => x.ToReduceExpression());
            return new CallReduceExpression(Name, Generic, args.ToArray());
        }
    }

    class GrammarIntExpr : IGrammarParamExpr
    {
        public bool IsIndex { get; }

        public int Value { get; }

        public GrammarIntExpr(int value, bool isIndex = false)
        {
            Value = value;
            IsIndex = isIndex;
        }
        

        public IReduceExpression ToReduceExpression()
        {
            int value = IsIndex ? Value - 1 : Value;

            return new IntReduceValue(value,
                IsIndex == true ? IntReduceValue.ValueTypes.Index : IntReduceValue.ValueTypes.Int);
        }
    }

    class GrammarStringExpr : IGrammarParamExpr
    {
        public string Value { get; }

        public GrammarStringExpr(string value)
        {
            Value = value;
        }


        public IReduceExpression ToReduceExpression()
        {
            if (string.IsNullOrEmpty(Value) == true)
                return StringReduceValue.Empty;

            return new StringReduceValue(Value);
        }
    }
}
