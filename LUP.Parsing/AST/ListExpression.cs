using System.Collections;

namespace LUP.Parsing.AST
{
    public class ListExpression<T> : IASTExpression, IEnumerable<T>
    {
        private readonly List<T> values;

        public int Count => values.Count;

        public ListExpression()
        {
            values = new();
        }


        public void AddFirst(T value)
        {
            values.Insert(0, value);
        }


        public void Add(T value)
        {
            values.Add(value);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
}
