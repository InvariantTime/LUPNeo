namespace LUP
{
    public class DisposableObject : IDisposable
    {
        public bool IsDisposed { get; private set; }


        ~DisposableObject()
        {
            DisposeInternal(false);
        }


        protected virtual void OnManagedDisposed()
        {
        }


        protected virtual void OnUnmanagedDisposed()
        {
        }


        public void Dispose()
        {
            DisposeInternal(true);
            GC.SuppressFinalize(this);
        }


        private void DisposeInternal(bool disposing)
        {
            if (disposing == true && IsDisposed == false)
            {
                OnManagedDisposed();
                IsDisposed = true;
            }
            else
            {
                OnUnmanagedDisposed();
            }
        }
    }
}
