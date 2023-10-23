using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering
{
    public readonly struct RawBuffer
    {
        public IntPtr Data { get; init; }

        public int Size { get; init; }


        public static RawBuffer New<T>(T[] data, int size) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                return new RawBuffer
                {
                    Data = handle.AddrOfPinnedObject(),
                    Size = size
                };
            }
            finally
            {
                if (handle.IsAllocated == true)
                    handle.Free();
            }
        }
    }
}
