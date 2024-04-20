using LUP.Parsing.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers.Reading
{
    class ReduceWriter
    {
        private readonly BinaryWriter writer;

        public ReduceWriter(BinaryWriter writer)
        {
            this.writer = writer;
        }


        public void Write(IReduceExpression expression)
        {
            var writer = GetWriter(expression);
            writer.Invoke();
        }


        private Action GetWriter(IReduceExpression expression)
        {
            return expression switch
            {
                EmptyReduceExpression emp => WriteEmpty,

                CallReduceExpression call => () => WriteCall(call),

                EqualReduceExpression equal => () => WriteEqual(equal),

                IntReduceValue val => () => WriteInt(val),

                SimpleReduceValue<string> str => () => WriteString(str),

                SimpleReduceValue<bool> bl => () => WriteBool(bl),

                _ => throw new NotSupportedException()
            };
        }


        private void WriteEmpty()
        {
            writer.Write((int)ReduceTypes.Empty);
        }


        private void WriteCall(CallReduceExpression call)
        {
            writer.Write((int)ReduceTypes.Call);

            writer.Write(call.Name);

            bool hasGeneric = string.IsNullOrEmpty(call.GenericName) == false;
            writer.Write(hasGeneric);

            if (hasGeneric == true)
                writer.Write(call.GenericName!);

            int argsCount = call.Args.Length;
            writer.Write(argsCount);

            for (int i = 0; i < argsCount; i++)
                Write(call.Args[i]);
        }


        private void WriteEqual(EqualReduceExpression equal)
        {
            writer.Write((int)ReduceTypes.Equal);
            Write(equal.Right);
        }


        private void WriteInt(IntReduceValue value)
        {
            var type = value.Type switch
            {
                IntReduceValue.ValueTypes.Int => ReduceTypes.Int,
                _ => ReduceTypes.Index
            };

            writer.Write((int)type);
            writer.Write(value.Value);
        }


        private void WriteString(SimpleReduceValue<string> value)
        {
            writer.Write((int)ReduceTypes.String);
            writer.Write(value.Value);
        }


        private void WriteBool(SimpleReduceValue<bool> value)
        {
            writer.Write((int)ReduceTypes.Bool);
            writer.Write(value.Value);
        }
    }
}
