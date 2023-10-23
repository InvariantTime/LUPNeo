using LUP.Graphics.Enums;
using LUP.Math;

namespace LUP.Graphics
{
    public interface IGraphicsCommandList
    {
        IVertexDrawer Drawer { get; }

        void SetView(Vector2 position, Vector2 size);

        void Clear();

        void SetState(GraphicsState state);

        void SetTextureBinding(TextureBindings binding);
    }
}