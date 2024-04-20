using LUP.Rendering.Materials.Sources;

namespace LUP.Rendering.Materials.Computes
{
    public interface IComputeValue
    {
        string Generate(MaterialContext context, MaterialKey key, MaterialSource source);
    }
}
