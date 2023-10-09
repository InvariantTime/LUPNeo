using LUP.Math;

namespace LUP.Client
{
    public interface IWindowRenderer
    {
        void Init(IntPtr window);

        void Render();

        void Resize(Vector2 size);
    }
}
