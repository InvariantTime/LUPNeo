namespace LUP.Math
{
    public static class LMath
    {
        public static float ToRadians(float degrees)
        {
            return (float)(degrees * System.Math.PI / 180);
        }


        public static float ToDegrees(float radians)
        {
            return (float)(radians * 180 / System.Math.PI);
        }


        public static Matrix4 LookAt(Vector3 position, Vector3 target, Vector3 up)
        {
            Matrix4 rotMat = new();

            Vector3 z = (target - position).Normalize();
            Vector3 x = Vector3.Cross(up, z).Normalize();
            Vector3 y = Vector3.Cross(z, x);

            rotMat.Row1 = new Vector4(x.X, y.X, z.X, 0);
            rotMat.Row2 = new Vector4(x.Y, y.Y, z.Y, 0);
            rotMat.Row3 = new Vector4(x.Z, y.Z, z.Z, 0);
            rotMat.Row4 = new Vector4(0, 0, 0, 1);

            rotMat.M41 = -x.Dot(position);
            rotMat.M42 = -y.Dot(position);
            rotMat.M43 = -z.Dot(position);

            return rotMat;
        }


        public static Matrix4 LookAtWithoutPosition(Vector3 target, Vector3 up)
        {
            Matrix4 rotMat = new();

            Vector3 z = target.Normalize();
            Vector3 x = Vector3.Cross(up, z).Normalize();
            Vector3 y = Vector3.Cross(z, x);

            rotMat.Row1 = new Vector4(x.X, y.X, z.X, 0);
            rotMat.Row2 = new Vector4(x.Y, y.Y, z.Y, 0);
            rotMat.Row3 = new Vector4(x.Z, y.Z, z.Z, 0);
            rotMat.Row4 = new Vector4(0, 0, 0, 1);

            return rotMat;
        }
    }
}
