
using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace LUP.Images
{
    public class Image : IDisposable
    {
        private readonly IntPtr ptr;

        public int Width { get; }

        public int Height { get; }

        public ImagePixelInfo PixelInfo { get; }

        internal Image(int width, int height, Rgba32[] pixels, ImagePixelInfo info)
        {
            Width = width;
            Height = height;
            PixelInfo = info;
            ptr = PinnedBuffer.Alloc(pixels);
        }


        public IntPtr GetIntPtr()
        {
            return ptr;
        }


        public void Dispose()
        {
            PinnedBuffer.Free(ptr);
            GC.SuppressFinalize(this);
        }
    }
}
