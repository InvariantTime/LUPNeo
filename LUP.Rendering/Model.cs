using LUP.Rendering.Materials;
using System.Collections.ObjectModel;

namespace LUP.Rendering
{
    public class Model
    {
        private readonly List<Mesh> meshes;
        private readonly Dictionary<int, RenderMaterial> materials;

        public IReadOnlyCollection<Mesh> Meshes { get; }

        public IReadOnlyDictionary<int, RenderMaterial> Materials { get; }

        public Model()
        {
            meshes = new();
            Meshes = new ReadOnlyCollection<Mesh>(meshes);

            materials = new();
            Materials = new ReadOnlyDictionary<int, RenderMaterial>(materials);
        }


        public void AddMesh(Mesh mesh)
        {
            if (mesh == null)
                return;

            if (meshes.Contains(mesh) == true)
                return;

            meshes.Add(mesh);
        }


        public void AddMaterial(int index, RenderMaterial material)
        {
            if (materials.ContainsKey(index) == true)
                throw new ArgumentException("There is already such index of material");

            materials.Add(index, material);
        }


        public void RemoveMesh(Mesh mesh)
        {
            meshes.Remove(mesh);
        }


        public void RemoveMaterial(int index)
        {
            materials.Remove(index);
        }
    }
}
