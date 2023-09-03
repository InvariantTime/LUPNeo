using LUP.DependencyInjection;

namespace LUP
{
    public abstract class LUPObject : IDisposable
    {
        public LApplication Core { get; }

        public IServicesProvider Services => Core.Services;

        public bool IsDisposed { get; private set; }

        public LUPObject()
        {
            if (LApplication.Current == null)
                throw new InvalidOperationException("LUP application is not initialized");

            Core = LApplication.Current;
        }



        public virtual void OnDispose()
        {

        }


        public void Dispose()
        {
            IsDisposed = true;
            OnDispose();
        }
    }
}
