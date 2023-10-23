namespace LUP.Graphics
{
    public struct Vec2<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public Vec2(T x, T y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Vec3<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public T Z { get; set; }

        public Vec3(T x, T y, T z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct Vec4<T>
    {
        public T X { get; set; }

        public T Y { get; set; }

        public T Z { get; set; }

        public T W { get; set; }

        public Vec4(T x, T y, T z, T w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
    }
}
