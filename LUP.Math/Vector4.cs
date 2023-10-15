using System.Diagnostics.CodeAnalysis;

namespace LUP.Math
{
    public struct Vector4
    {
        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float W { get; set; }

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }


        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null)
                return false;

            if (obj is not Vector4 o)
                return false;

            return X == o.X && Y == o.Y
                && Z == o.Z && W == o.W;
        }


        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode()
                + Z.GetHashCode() + W.GetHashCode();
        }


        public static Vector4 operator *(Vector4 vector, float value)
        {
            return new Vector4(vector.X * value, vector.Y * value,
                vector.Z * value, vector.W * value);
        }


        public static Vector4 operator -(Vector4 vector)
        {
            return vector * (-1);
        }


        public static Vector4 operator /(Vector4 vector, float value)
        {
            return new Vector4(vector.X / value, vector.Y / value,
                vector.Z / value, vector.W / value);
        }


        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y,
                left.Z + right.Z, left.W + right.W);
        }


        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return left + (right * (-1));
        }


        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(right) == true;
        }


        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return left.Equals(right) == false;
        }
    }
}
