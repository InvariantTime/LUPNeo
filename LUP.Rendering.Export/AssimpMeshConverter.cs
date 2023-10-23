using Assimp;
using LUP.Graphics.Enums;
using LUP.Math;
using LUP.Rendering.Meshing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AssimpMesh = Assimp.Mesh;

namespace LUP.Rendering.Export
{
    static class AssimpMeshConverter
    {
        private static readonly VertexDescription description = new(new VertexElement[]
        {
            new VertexElement(DefaultVertexElements.Position, VertexAttribPointerTypes.Float, 0, 32),
            new VertexElement(DefaultVertexElements.UV, VertexAttribPointerTypes.Float, 12, 32),
            new VertexElement(DefaultVertexElements.Normal, VertexAttribPointerTypes.Float, 20, 32),
        });

        public static RawMesh Convert(AssimpMesh mesh)
        {
            Vertex[] vertices = new Vertex[mesh.VertexCount];
            List<uint> indices = new();

            for (int i = 0; i < vertices.Length; i++)
            {
                var uv = mesh.TextureCoordinateChannels.Length > 0 ?
                    mesh.TextureCoordinateChannels[0][i] : new Vector3D();

                var normal = mesh.HasNormals ? mesh.Normals[i].Convert() : Vector3.Zero;

                vertices[i] = new Vertex
                {
                    Position = mesh.Vertices[i].Convert(),
                    Normal = normal,
                    UV = new Vector2(uv.X, uv.Y)
                };
            }

            for (int i = 0; i < mesh.FaceCount; i++)
            {
                if (mesh.Faces[i].IndexCount == 3)
                {
                    indices.Add((uint)mesh.Faces[i].Indices[0]);
                    indices.Add((uint)mesh.Faces[i].Indices[1]);
                    indices.Add((uint)mesh.Faces[i].Indices[2]);
                }
            }

            var verticesBuffer = new RawVertices
            {
                Description = description,
                Buffer = RawBuffer.New(vertices, Vertex.Size * vertices.Length)
            };

            var indexBuffer = RawBuffer.New(indices.ToArray(), sizeof(uint) * indices.Count);

            return new RawMesh
            {
                Vertices = verticesBuffer,
                Indices = indexBuffer,
                Count = indices.Count
            };
        }
    }

    struct Vertex
    {
        public const int Size = 32;

        public Vector3 Position { get; set; }

        public Vector2 UV { get; set; }

        public Vector3 Normal { get; set; }
    }
}
