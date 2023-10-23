using LUP.Graphics;
using LUP.Math;
using LUP.Rendering.RenderObjects;
using LUP.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Components
{
    public class ModelComponent : ActivableComponent, IRenderProvider
    {
        private readonly List<Mesh> meshes;

        private IEffect Effect { get; }

        public ModelComponent(IEffect effect)
        {
            Effect = effect;
            meshes = new();
        }


        public void AddMesh(Mesh mesh)
        {
            meshes.Add(mesh);
        }


        public void Visit(IRenderVisitor visitor)
        {
            if (meshes.Count == 0)
                return;

            if (meshes.Count == 1)
            {
                visitor.Visit(new RenderMesh(meshes[0], Effect));
                return;
            }

            visitor.VisitMany(meshes.Select(x => new RenderMesh(x, Effect)));
        }
    }
}
