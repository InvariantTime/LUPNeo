using LUP.Graphics;
using LUP.Math;

namespace LUP.Rendering.RenderObjects
{
    public class RenderMesh : RenderObject
    {
        public Mesh Mesh { get; }

        public IEffect? Effect { get; }

        public Matrix4 Transform { get; } = Matrix4.Identity;
        
        public RenderMesh(Mesh mesh, IEffect? effect)
        {
            Mesh = mesh;
            Effect = effect;
        }


        public RenderMesh(Mesh mesh) : this(mesh, null)
        {
        }
    }
}
