namespace LUP.Math
{
    public class Perspective3D
    {
        private const float aspectRatio = 16f / 9f;
        private const float pov = 60f;
        private const float zNear = 0.1f;
        private const float zFar = 1000;

        private Matrix4 matrix;

        public float AspectRatio { get; private set; }

        public float POV { get; private set; }

        public float ZNear { get; private set; }

        public float ZFar { get; private set; }

        public Perspective3D(float aspectRatio, float pov, float znear, float zfar)
        {
            if (znear < 0)
                throw new ArgumentException("znear must be greater than 0");

            if (zfar < 0)
                throw new ArgumentException("zfar must be greater than 0");

            if (znear > zfar)
                throw new ArgumentException("zfar must be greater than znear");

            if (aspectRatio < 0)
                throw new ArgumentException("aspect ratio must be greater than 0");

            if (pov < 0)
                throw new ArgumentException("pov must be greater than 0");

            AspectRatio = aspectRatio;
            POV = pov;
            ZNear = znear;
            ZFar = zfar;

            UpdateMatrix();
        }


        public Perspective3D() : this(aspectRatio, pov, zNear, zFar)
        {
        }


        public void SetPOV(float value)
        {
            if (value < 0)
                throw new ArgumentException("pov must be greater than 0");

            POV = value;
            UpdateMatrix();
        }


        public void SetAspectRation(float value)
        {
            if (value < 0)
                throw new ArgumentException("aspect ratio must be greater than 0");

            AspectRatio = value;
            UpdateMatrix();
        }


        public void SetPlane(float znear, float zfar)
        {
            if (znear < 0)
                throw new ArgumentException("znear must be greater than 0");

            if (zfar < 0)
                throw new ArgumentException("zfar must be greater than 0");

            if (znear > zfar)
                throw new ArgumentException("zfar must be greater than znear");

            ZNear = znear;
            ZFar = zfar;
            UpdateMatrix();
        }


        public Matrix4 GetMatrix()
        {
            return matrix;
        }


        private void UpdateMatrix()
        {
            float sclY = (float)(1.0f / System.Math.Tan(LMath.ToRadians(POV / 2f)));
            float sclX = sclY / AspectRatio;
            float zRange = ZFar / (ZFar - ZNear);

            matrix = new Matrix4
            {
                Row1 = new Vector4(sclX, 0, 0, 0),
                Row2 = new Vector4(0, sclY, 0, 0),
                Row3 = new Vector4(0, 0, zRange, 1),
                Row4 = new Vector4(0, 0, -ZNear * zRange, 0)
            };
        }
    }
}
