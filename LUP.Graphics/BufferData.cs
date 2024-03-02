using System.Runtime.InteropServices;

namespace LUP.Graphics
{
    public readonly struct BufferData : IDisposable
    {
        public static readonly BufferData Empty = new();

        public IntPtr Pointer { get; }

        public int Size { get; }

        private BufferData(IntPtr ptr, int size)
        {
            Pointer = ptr;
            Size = size;
        }
        

        public static BufferData Create(IntPtr ptr, int size)
        {
            return new(ptr, size);
        }
        

        public static unsafe BufferData Create(void* ptr, int size)
        {
            return new(new IntPtr(ptr), size);
        }


        public static BufferData Create<T>(T[] array, int size) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
            
            try
            {
                return new(handle.AddrOfPinnedObject(), size);
            }
            finally
            {
                if (handle.IsAllocated == true)
                    handle.Free();
            }
        }


        public static BufferData Create<T>(T str, int size) where T : struct
        {
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(str, ptr, true);
            return new BufferData(ptr, size);
        }


        public static BufferData Create(int size)
        {
            IntPtr ptr = Marshal.AllocHGlobal(size);
            return new BufferData(ptr, size);
        }

        
        public static void Reallocate<T>(BufferData data, T @struct)
            where T : struct
        {
            Marshal.StructureToPtr(@struct, data.Pointer, true);
        }


        public void Dispose()
        {
            Marshal.FreeHGlobal(Pointer);
        }
    }
}
