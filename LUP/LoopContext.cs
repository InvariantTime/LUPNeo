namespace LUP
{
    public class LoopContext
    {
        public CancellationToken Cancellation { get; }

        public LoopContext(CancellationToken token)
        {
            Cancellation = token;
        }
    }
}
