using Assimp;
using LUP.Graphics;
using LUP.Rendering.Contexts;

namespace LUP.Rendering.Export
{
    public class ModelImporter
    {
        private readonly IGraphicsAllocator allocator;

        public ModelImporter(IGraphicsAllocator allocator)
        {
            this.allocator = allocator;
        }


        public ModelResult Import(string file)
        {
            using AssimpContext context = new();
            var scene = context.ImportFile(file, PostProcessSteps.Triangulate
                | PostProcessSteps.CalculateTangentSpace 
                | PostProcessSteps.FlipUVs | PostProcessSteps.GenerateNormals);

            return new ModelResult
            {
                Meshes = scene.Meshes.Select(x => AssimpMeshConverter.Convert(x, allocator)).ToArray()
            };
        }
    }
}