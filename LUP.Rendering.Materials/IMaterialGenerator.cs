
namespace LUP.Rendering.Materials
{
    public interface IMaterialGenerator
    {
        RenderMaterial Generate(IMaterialDescriptor descriptor);
    }
}