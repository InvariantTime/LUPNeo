
namespace LUP.Parsing.AST
{
    public interface IValueExpression : IASTExpression
    {
        Type ValueType { get; }

        object GetValue();
    }

    public class ValueExpression<T> : IValueExpression
    {
        public T Value { get; }

        public Type ValueType { get; } = typeof(T);

        public ValueExpression(T value)
        {
            Value = value;
        }


        public object GetValue()
        {
            return Value!;
        }


        public override string ToString()
        {
            return Value!.ToString() ?? string.Empty;
        }
    }
}
