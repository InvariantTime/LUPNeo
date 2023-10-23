using LUP.Graphics;
using LUP.Graphics.Enums;
using LUP.Math;
using LUP.Rendering;
using LUP.Rendering.Meshing;

namespace Rendering_Example
{
    public static class Meshes
    {
        private const float offsetRadius = 20f;
        private const float offset = 0.01f;

        private static readonly VertexAttribPointer[] pointers =
        {
            new VertexAttribPointer(0, 3, VertexAttribPointerTypes.Float, 0, 0)
        };

        public static Mesh CreateMesh(IGraphicsDevice device)
        {
            var vbo = device.DataBuffers.Invoke(BufferTypes.Array);

            var triangle = GenerateTriangle();
            vbo.SetData(triangle.AsVectors(), Triangle.Size, BufferUsages.StaticDraw);

            Mesh mesh = new(new MeshDraw
            {
                Vertices = new VerticesBinding(vbo, new VertexDescription(new VertexElement[]
                {
                    new VertexElement(DefaultVertexElements.Position, VertexAttribPointerTypes.Float, 0, 0)
                })),
                Count = 3
            });

            return mesh;
        }


        private static Triangle GenerateTriangle()
        {
            Vector3 position = new Vector3(0, 0, 100);

            Vector3 offset1 = GenerateVector3(offset, offsetRadius);
            Vector3 offset2 = GenerateVector3(offset, offsetRadius);
            Vector3 offset3 = GenerateVector3(offset, offsetRadius);

            return new Triangle
            {
                Point1 = position + offset1,
                Point2 = position + offset2,
                Point3 = position + offset3
            };
        }


        private static Vector3 GenerateVector3(float offset, float radius)
        {
            var rand = Random.Shared;
            float GetCoord() => (rand.NextSingle() * 2 - 1) * radius + offset;

            float x = GetCoord();
            float y = GetCoord();
            float z = GetCoord();

            return new Vector3(x, y, 0);
        }



        readonly struct Triangle
        {
            public static readonly int Size = 36;

            public Vector3 Point1 { get; init; }

            public Vector3 Point2 { get; init; }

            public Vector3 Point3 { get; init; }

            public Vector3[] AsVectors()
            {
                return new Vector3[]
                {
                    Point1,
                    Point2,
                    Point3
                };
            }
        }
    }
}
