namespace LUP.Utils
{
    public interface IOption<T> where T : new()
    {
        T Accessor { get; }
    }

    public class Option<T> : IOption<T> where T : new()
    {
        public T Accessor { get; }

        public Option(T Accessor)
        {
            this.Accessor = Accessor;
        }


        public Option()
        {
            Accessor = new();
        }
    }
}
