
namespace LUP.App.Contexts
{
    public class LoopContext
    {
        public bool IsLoop { get; private set; }

        public LoopContext()
        {
            IsLoop = true;
        }

        public void Stop()
        {
            IsLoop = false;
        }
    }
}
