using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace LUP.Math
{
    public struct Matrix4
    {
        public static readonly Matrix4 Identity = new()
        {
            M11 = 1f,
            M22 = 1f,
            M33 = 1f,
            M44 = 1f,
        };

        public static readonly Matrix4 Zero = new();

        public float M11;

        public float M12;

        public float M13;

        public float M14;

        public float M21;

        public float M22;

        public float M23;

        public float M24;

        public float M31;

        public float M32;

        public float M33;

        public float M34;

        public float M41;

        public float M42;

        public float M43;

        public float M44;

        public Vector4 Row1
        {
            get => new(M11, M12, M13, M14);

            set
            {
                M11 = value.X;
                M12 = value.Y;
                M13 = value.Z;
                M14 = value.W;
            }
        }

        public Vector4 Row2
        {
            get => new(M21, M22, M23, M24);

            set
            {
                M21 = value.X;
                M22 = value.Y;
                M23 = value.Z;
                M24 = value.W;
            }
        }

        public Vector4 Row3
        {
            get => new(M31, M32, M33, M34);

            set
            {
                M31 = value.X;
                M32 = value.Y;
                M33 = value.Z;
                M34 = value.W;
            }
        }

        public Vector4 Row4
        {
            get => new(M41, M42, M43, M44);

            set
            {
                M41 = value.X;
                M42 = value.Y;
                M43 = value.Z;
                M44 = value.W;
            }
        }


        public Matrix4(Vector4 row1, Vector4 row2, Vector4 row3, Vector4 row4)
        {
            Row1 = row1;
            Row2 = row2;
            Row3 = row3;
            Row4 = row4;
        }


        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null)
                return false;

            if (obj is not Matrix4 o)
                return false;

            return Row1 == o.Row1 && Row2 == o.Row2 &&
                Row3 == o.Row3 && Row4 == o.Row4;
        }


        public override int GetHashCode()
        {
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M14.GetHashCode() +
                M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M24.GetHashCode() +
                M31.GetHashCode() + M12.GetHashCode() + M33.GetHashCode() + M34.GetHashCode() +
                M41.GetHashCode() + M12.GetHashCode() + M43.GetHashCode() + M44.GetHashCode();
        }


        public Matrix4 Transpose()
        {
            return new Matrix4
            {
                Row1 = new Vector4(M11, M21, M31, M41),
                Row2 = new Vector4(M12, M22, M32, M42),
                Row3 = new Vector4(M13, M23, M33, M43),
                Row4 = new Vector4(M14, M24, M34, M44)
            };
        }


        public static Matrix4 CreateTranslation(Vector3 position)
        {
            return new Matrix4
            {
                M11 = 1,
                M22 = 1,
                M33 = 1,
                M44 = 1,
                M41 = position.X,
                M42 = position.Y,
                M43 = position.Z
            };
        }


        public static Matrix4 CreateScaling(Vector3 scale)
        {
            return new Matrix4
            {
                M11 = scale.X,
                M22 = scale.Y,
                M33 = scale.Z,
                M44 = 1
            };
        }


        public static Matrix4 operator *(Matrix4 matrix, float value)
        {
            return new Matrix4()
            {
                Row1 = matrix.Row1 * value,
                Row2 = matrix.Row2 * value,
                Row3 = matrix.Row3 * value,
                Row4 = matrix.Row4 * value
            };
        }


        public static Matrix4 operator -(Matrix4 matrix)
        {
            return matrix * (-1);
        }


        public static Matrix4 operator /(Matrix4 matrix, float value)
        {
            return new Matrix4()
            {
                Row1 = matrix.Row1 / value,
                Row2 = matrix.Row2 / value,
                Row3 = matrix.Row3 / value,
                Row4 = matrix.Row4 / value
            };
        }


        public static Matrix4 operator +(Matrix4 left, Matrix4 right)
        {
            return new Matrix4()
            {
                Row1 = left.Row1 + right.Row1,
                Row2 = left.Row2 + right.Row2,
                Row3 = left.Row3 + right.Row3,
                Row4 = left.Row4 + right.Row4
            };
        }


        public static Matrix4 operator -(Matrix4 left, Matrix4 right)
        {
            return new Matrix4()
            {
                Row1 = left.Row1 - right.Row1,
                Row2 = left.Row2 - right.Row2,
                Row3 = left.Row3 - right.Row3,
                Row4 = left.Row4 - right.Row4
            };
        }


        public static Matrix4 operator *(Matrix4 left, Matrix4 right)
        {
            return new Matrix4()
            {
                M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41,
                M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42,
                M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43,
                M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44,

                M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41,
                M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42,
                M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43,
                M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44,

                M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41,
                M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42,
                M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43,
                M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44,

                M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41,
                M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42,
                M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43,
                M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44,
            };
        }


        public static bool operator ==(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right) == true;
        }


        public static bool operator !=(Matrix4 left, Matrix4 right)
        {
            return left.Equals(right) == false;
        }
    }
}
