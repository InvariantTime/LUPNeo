namespace LUP
{
    public class LoopContext
    {
        public CancellationTokenSource Cancellation { get; }

        public LoopContext(CancellationTokenSource cancellation)
        {
            Cancellation = cancellation;
        }
    }
}
