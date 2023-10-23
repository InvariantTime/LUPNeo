using LUP.Graphics;
using LUP.Graphics.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Meshing
{
    public static class MeshBuilder
    {
        public static Mesh Build(RawMesh data, IGraphicsDevice device)
        {
            var vbo = device.DataBuffers.Invoke(BufferTypes.Array);
            vbo.SetData(data.Vertices.Buffer.Data, data.Vertices.Buffer.Size, BufferUsages.StaticDraw);

            var ebo = device.DataBuffers.Invoke(BufferTypes.Element);
            ebo.SetData(data.Indices!.Value.Data, data.Indices!.Value.Size, BufferUsages.StaticDraw);

            var draw = new MeshDraw()
            { 
                Vertices = new VerticesBinding(vbo, data.Vertices.Description),
                Indices = new IndicedBinding(ebo),
                Count = data.Count,
                StartLocation = 0,
                Primitive = PrimitiveTypes.Triangles
            };

            Mesh mesh = new(draw);
            return mesh;
        }
    }
}
