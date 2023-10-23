using Assimp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssimpScene = Assimp.Scene;

namespace LUP.Rendering.Export
{
    public static class ModelImporter
    {
        public static ModelResult Import(string file)
        {
            using AssimpContext context = new();
            var scene = context.ImportFile(file, PostProcessSteps.Triangulate
                | PostProcessSteps.CalculateTangentSpace 
                | PostProcessSteps.FlipUVs | PostProcessSteps.GenerateNormals);


            return new ModelResult
            {
                Meshes = scene.Meshes.Select(AssimpMeshConverter.Convert).ToArray()
            };
        }
    }
}