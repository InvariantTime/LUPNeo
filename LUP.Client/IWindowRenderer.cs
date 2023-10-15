using LUP.Math;

namespace LUP.Client
{
    public interface IWindowRenderer
    {
        void Init(IntPtr window, int width, int height);

        void Render();

        void Resize(Vector2 size);
    }
}
