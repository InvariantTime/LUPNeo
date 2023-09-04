using LUP.DependencyInjection;
using LUP.Logging;

namespace LUP
{
    public abstract class LUPObject : IDisposable
    {
        public LApplication Core { get; }

        public ILogger Logger { get; }

        public IServicesProvider Services => Core.Services;

        public bool IsDisposed { get; private set; }

        public LUPObject()
        {
            if (LApplication.Current == null)
                throw new InvalidOperationException("LUP application is not initialized");

            Core = LApplication.Current;
            Logger = Services.GetService<ILogger>() ?? throw new InvalidOperationException();
        }


        public virtual void OnDispose()
        {
        }


        public void Dispose()
        {
            OnDispose();

            IsDisposed = true;
        }
    }
}
