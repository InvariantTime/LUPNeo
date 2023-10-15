namespace LUP.Math
{
    public struct Quaternion
    {
        public static readonly Quaternion Identity = new(0, 0, 0, 1);

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public float W { get; set; }

        public Vector3 XYZ => new(X, Y, Z);

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }


        public Quaternion(Vector3 axis, float degrees)
        {
            float a = LMath.ToRadians(degrees) / 2;

            float sin = (float)System.Math.Sin(a);
            float cos = (float)System.Math.Cos(a);

            X = axis.X * sin;
            Y = axis.Y * sin;
            Z = axis.Z * sin;
            W = cos;
        }


        public Quaternion()
        {
            W = 1;
        }


        public void Rotate(Vector3 value, float angle)
        {
            float ang = LMath.ToRadians(angle);

            X = value.X * (float)System.Math.Sin(ang);
            Y = value.Y * (float)System.Math.Sin(ang);
            Z = value.Z * (float)System.Math.Sin(ang);
            W = (float)System.Math.Cos(ang);
        }


        public Matrix4 GetMatrix()
        {
            float sqx = X * X;
            float sqy = Y * Y;
            float sqz = Z * Z;
            float sqw = W * W;

            float xy = X * Y;
            float xz = X * Z;
            float xw = X * W;

            float yz = Y * Z;
            float yw = Y * W;

            float zw = Z * W;

            float s2 = 2f / (sqx + sqy + sqz + sqw);

            Vector4 row1 = new();
            Vector4 row2 = new();
            Vector4 row3 = new();

            row1.X = 1f - (s2 * (sqy + sqz));
            row2.Y = 1f - (s2 * (sqx + sqz));
            row3.Z = 1f - (s2 * (sqx + sqy));

            row1.Y = s2 * (xy + zw);
            row2.X = s2 * (xy - zw);

            row3.X = s2 * (xz + yw);
            row1.Z = s2 * (xz - yw);

            row3.Y = s2 * (yz - xw);
            row2.Z = s2 * (yz + xw);

            row1.W = 0;
            row2.W = 0;
            row3.W = 0;

            Vector4 row4 = new(0, 0, 0, 1);

            return new Matrix4(row1, row2, row3, row4);
        }


        public Quaternion GetPairing()
        {
            return new(-X, -Y, -Z, W);
        }


        public static Vector3 RotateVector(Vector3 vec, Quaternion quaternion)
        {
            Vector3 result = Vector3.Zero;

            Quaternion qv = quaternion * vec;
            Quaternion qq1 = qv * quaternion.GetPairing();

            result.X = qq1.X;
            result.Y = qq1.Y;
            result.Z = qq1.Z;

            return result;
        }


        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Vector3 cv = Vector3.Cross(left.XYZ, right.XYZ);

            Vector3 vec = (right.W * left.XYZ) + (left.W * right.XYZ) + cv;
            float w = (left.W * right.W) - left.XYZ.Dot(right.XYZ);

            return new Quaternion(vec.X, vec.Y, vec.Z, w);
        }


        public static Quaternion operator *(Quaternion quat, Vector3 vec)
        {
            Quaternion res = new Quaternion(new Vector3(), 0);


            Vector3 cv = Vector3.Cross(
                new Vector3(quat.X, quat.Y, quat.Z),
                vec);

            res.W = -(quat.X * vec.X) - (quat.Y * vec.Y) - (quat.Z * vec.Z);
            res.X = (quat.W * vec.X) + cv.X;
            res.Y = (quat.W * vec.Y) + cv.Y;
            res.Z = (quat.W * vec.Z) + cv.Z;

            return res;
        }


        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            Quaternion result = new Quaternion();
            result.X = left.X + right.X;
            result.Y = left.Y + right.Y;
            result.Z = left.Z + right.Z;
            result.W = left.W + right.W;

            return result;
        }


        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            Quaternion result = new Quaternion();
            result.X = left.X - right.X;
            result.Y = left.Y - right.Y;
            result.Z = left.Z - right.Z;
            result.W = left.W - right.W;

            return result;
        }
    }
}
