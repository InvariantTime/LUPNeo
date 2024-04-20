using LUP.Graphics.Enums;
using LUP.Rendering.Materials.Computes;
using LUP.Rendering.Materials.Shaders;
using LUP.Rendering.Materials.Sources;

namespace LUP.Rendering.Materials
{
    public class MaterialDescriptor : IMaterialDescriptor
    {
        public IComputeColor? Albedo { get; set; }

        public void Generate(MaterialContext context)
        {
        }
    }
}
