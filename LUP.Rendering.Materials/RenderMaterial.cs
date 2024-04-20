
namespace LUP.Rendering.Materials
{
    public class RenderMaterial
    {
        public RenderMaterialPass Pass { get; }

        public RenderMaterial(RenderMaterialPass pass)
        {
            Pass = pass;
        }
    }
}
