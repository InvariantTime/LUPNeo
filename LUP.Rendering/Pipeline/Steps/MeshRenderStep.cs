using LUP.Graphics;
using LUP.Rendering.RenderObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Pipeline.Steps
{
    public class MeshRenderStep : RootRenderStep
    {
        public override void Draw(RenderScene scene)
        {
            var drawer = Context.Device.GetCommandList().Drawer;

            foreach (var obj in scene.Compositor.Objects)
            {
                if (obj is RenderMesh mesh)
                {
                    if (mesh.Effect == null)
                        continue;

                    mesh.Effect.Bind();
                    Render(drawer, mesh.Mesh.Draw);
                    mesh.Effect.Unbind();
                }
            }
        }


        private static void Render(IVertexDrawer drawer, MeshDraw mesh)
        {
            mesh.Vertices.Prepare(drawer);

            if (mesh.Indices == null)
            {
                drawer.Draw(mesh.Primitive, mesh.StartLocation, mesh.Count);
            }
            else
            {
                mesh.Indices.EBO.Bind();
                drawer.DrawIndiced(mesh.Primitive, mesh.StartLocation, mesh.Count);
                mesh.Indices.EBO.Unbind();
            }

            mesh.Vertices.Unbind();
        }
    }
}
