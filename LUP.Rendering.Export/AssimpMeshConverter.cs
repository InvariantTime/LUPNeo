using Assimp;
using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Math;
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
        ///TODO: descripton must be muttable
        private static readonly VertexFormat description = new(new VertexAttribute[]
        {
            new(DefaultVertexElements.Position, 3, VertexAttribPointerTypes.Float, 32, 0),
            new(DefaultVertexElements.UV, 2, VertexAttribPointerTypes.Float, 32, 12),
            new(DefaultVertexElements.Normal, 3, VertexAttribPointerTypes.Float, 32, 20),
        });

        public static Mesh Convert(AssimpMesh mesh, IGraphicsAllocator allocator)
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

            var vertexBuffer = allocator.BuildBuffer(new()
            {
                Data = BufferData.Create(vertices, vertices.Length * Vertex.Size),
                Type = BufferTypes.Array,
                Usage = BufferUsages.StaticDraw
            });

            var indexBuffer = allocator.BuildBuffer(new()
            {
                Data = BufferData.Create(indices.ToArray(), indices.Count * sizeof(uint)),
                Type = BufferTypes.Element,
                Usage = BufferUsages.StaticDraw
            });

            return new Mesh(new VertexBufferBinding(vertexBuffer, description),
                new(indexBuffer, 0, indices.Count), new DrawData()
            {
                Count = indices.Count,
                First = 0,
                IsIndixed = true,
                Primitive = PrimitiveTypes.Triangles
            });
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
