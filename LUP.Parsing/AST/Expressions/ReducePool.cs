using LUP.Parsing.Parsers;
using System.Collections;

namespace LUP.Parsing.AST.Expressions
{
    public sealed class ReducePool : IEnumerable<KeyValuePair<KeyToken, IASTExpression>>
    {
        private readonly Dictionary<KeyToken, IASTExpression> expressions;

        public ReducePool()
        {
            expressions = new();
        }


        public IASTExpression GetAST(KeyToken key)
        {
            bool has = expressions.TryGetValue(key, out var value);

            if (has == false)
            {
                if (key.IsTerminal == false)
                    throw new InvalidOperationException($"Non terminal {key.Token.Type}:{key.Key} is not initialized");

                value = new ValueExpression<string>(key.Token.Value ?? string.Empty);
                expressions.Add(key, value);
            }

            return value!;
        }


        public void AddExpression(KeyToken key, IASTExpression expression)
        {
            expressions.Add(key, expression);
        }


        public void Clear()
        {
            expressions.Clear();
        }


        public IEnumerator<KeyValuePair<KeyToken, IASTExpression>> GetEnumerator()
        {
            return expressions.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
