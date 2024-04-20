using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace LUP
{
    public static class PinnedBuffer
    {
        private static readonly ConcurrentDictionary<IntPtr, GCHandle> handles = new();

        public static IntPtr Alloc<T>(T[] array) where T : struct
        {
            try
            {
                var handle = GCHandle.Alloc(array, GCHandleType.Pinned);
                var ptr = handle.AddrOfPinnedObject();

                handles.TryAdd(ptr, handle);
                return ptr;
            }
            finally
            {
            }
        }


        public static void Free(IntPtr ptr)
        {
            bool has = handles.TryGetValue(ptr, out var handle);

            if (has == false)
                return;

            if (handle.IsAllocated == true)
                handle.Free();

            handles.Remove(ptr, out _);
        }
    }
}
