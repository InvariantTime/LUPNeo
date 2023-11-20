using LUP.Parsing.AST.Expressions;

namespace LUP.Parsing.Parsers.Reading
{
    class ReduceReader
    {
        private readonly BinaryReader reader;

        public ReduceReader(BinaryReader reader)
        {
            this.reader = reader;
        }


        public IReduceExpression Build()
        {
            var type = (ReduceTypes)reader.ReadInt32();

            var builder = GetBuilder(type);
            return builder.Invoke();
        }


        private Func<IReduceExpression> GetBuilder(ReduceTypes type)
        {
            return type switch
            {
                ReduceTypes.Empty => BuildEmpty,

                ReduceTypes.Call => BuildCall,

                ReduceTypes.Equal => BuildEqual,

                ReduceTypes.Int => () => BuildInt(IntReduceValue.ValueTypes.Int),

                ReduceTypes.Index => () => BuildInt(IntReduceValue.ValueTypes.Index),

                ReduceTypes.String => BuildString,

                _ => throw new NotSupportedException()
            };
        }


        private CallReduceExpression BuildCall()
        {
            string name = reader.ReadString();
            bool hasGeneric = reader.ReadBoolean();
            string? generic = hasGeneric == true ? reader.ReadString() : null;
            
            int argCount = reader.ReadInt32();
            IReduceExpression[] expressions = new IReduceExpression[argCount];

            for (int i = 0; i < argCount; i++)
                expressions[i] = Build();

            return new CallReduceExpression(name, generic, expressions);
        }


        private EqualReduceExpression BuildEqual()
        {
            var right = Build();
            return new EqualReduceExpression(right);
        }


        private EmptyReduceExpression BuildEmpty()
        {
            return EmptyReduceExpression.Instance;
        }


        private IntReduceValue BuildInt(IntReduceValue.ValueTypes type)
        {
            int value = reader.ReadInt32();
            return new IntReduceValue(value, type);
        }


        private StringReduceValue BuildString()
        {
            string value = reader.ReadString();

            if (string.IsNullOrEmpty(value) == true)
                return StringReduceValue.Empty;

            return new StringReduceValue(value);
        }
    }

    enum ReduceTypes
    {
        Empty = 0,

        Call = 1,

        Equal = 2,

        Int = 3,

        Index = 4,

        String = 5
    }
}
