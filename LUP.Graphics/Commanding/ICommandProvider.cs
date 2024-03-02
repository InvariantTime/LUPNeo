
namespace LUP.Graphics.Commanding
{
    public interface IGraphicsCommandCollector
    {
        void Collect(uint command, Action<object?> action);
    }

    public interface IGraphicsCommandProvider
    {
        void InitializeCommands(IGraphicsCommandCollector collector);
    }

    public static class GraphicsCommandCollectorExtension
    {
        public static void Collect(this IGraphicsCommandCollector collector, uint command, Action action)
        {
            collector.Collect(command, _ => action.Invoke());
        }


        public static void Collect<T>(this IGraphicsCommandCollector collector, uint command, Action<T> action)
        {
            collector.Collect(command, o =>
            {
                if (o is not T t)
                    throw new InvalidCastException($"Unable to cast {o.GetType().FullName} to {typeof(T).FullName}");

                action.Invoke(t);
            });
        }


        public static void Collect<T1, T2>(this IGraphicsCommandCollector collector, uint command, Action<T1, T2> action)
        {
            collector.Collect(command, o =>
            {
                if (o is not ValueTuple<T1, T2> data)
                    throw new InvalidCastException();

                action.Invoke(data.Item1, data.Item2);
            });
        }
    }
}
