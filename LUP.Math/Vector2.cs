namespace LUP.Math
{
    public struct Vector2
    {
        public static readonly Vector2 Zero = new();

        public float X { get; set; }

        public float Y { get; set; }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }


        public static Vector2 operator *(Vector2 vector, float value)
        {
            return new Vector2(vector.X * value, vector.Y * value);
        }


        public static Vector2 operator /(Vector2 vector, float value)
        {
            return new Vector2(vector.X / value, vector.Y / value);
        }


        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }


        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return left + (right * (-1));
        }


        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
