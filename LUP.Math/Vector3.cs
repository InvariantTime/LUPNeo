namespace LUP.Math
{
    public struct Vector3
    {
        public static readonly Vector3 Zero = new(0, 0, 0);

        public static readonly Vector3 Forward = new(0, 0, 1);

        public static readonly Vector3 Back = new(0, 0, -1);

        public static readonly Vector3 Left = new(-1, 0, 0);

        public static readonly Vector3 Right = new(1, 0, 0);

        public static readonly Vector3 Up = new(0, 1, 0);

        public static readonly Vector3 Down = new(0, -1, 0);

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public float GetLength()
        {
            return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }


        public Vector3 Normalize()
        {
            float length = GetLength();

            if (length == 0)
                return Vector3.Zero;

            return new Vector3(X, Y, Z) / length;
        }


        public static Vector3 Cross(Vector3 v1, Vector3 v2)
        {
            float x = v1.Y * v2.Z - v1.Z * v2.Y;
            float y = v1.Z * v2.X - v1.X * v2.Z;
            float z = v1.X * v2.Y - v1.Y * v2.X;

            return new Vector3(x, y, z);
        }


        public float Dot(Vector3 other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }


        public static Vector3 operator *(Vector3 vector, float value)
        {
            return new Vector3(vector.X * value, vector.Y * value,
                vector.Z * value);
        }


        public static Vector3 operator *(float value, Vector3 vector)
        {
            return new Vector3(vector.X * value, vector.Y * value,
                vector.Z * value);
        }


        public static Vector3 operator -(Vector3 vector)
        {
            return vector * (-1);
        }


        public static Vector3 operator /(Vector3 vector, float value)
        {
            return new Vector3(vector.X / value, vector.Y / value,
                vector.Z / value);
        }


        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y,
                left.Z + right.Z);
        }


        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return left + (right * (-1));
        }
    }
}
