namespace MathTest
{
    [TestClass]
    public class Matrix4Tests
    {
        private static readonly Matrix4 matrix1 = new()
        {
            Row1 = new Vector4(3, 5, 9, 12),
            Row2 = new Vector4(1, 8, 10, 53),
            Row3 = new Vector4(0, 10, 3, 48),
            Row4 = new Vector4(123, 5, 2, 30),
        };

        private static readonly Matrix4 matrix2 = new()
        {
            Row1 = new Vector4(33, 15, 28, 19),
            Row2 = new Vector4(53, 98, 101, 43),
            Row3 = new Vector4(10, 10, 3243, 12),
            Row4 = new Vector4(1233, 125, 20, 35),
        };

        [TestMethod]
        public void MatrixSum()
        {
            Matrix4 matrix = matrix1 + matrix2;

            Matrix4 result = new()
            {
                Row1 = new Vector4(36, 20, 37, 31),
                Row2 = new Vector4(54, 106, 111, 96),
                Row3 = new Vector4(10, 20, 3246, 60),
                Row4 = new Vector4(1356, 130, 22, 65)
            };

            Assert.AreEqual(matrix, result);
        }


        [TestMethod]
        public void MatrixMultiply()
        {
            Matrix4 matrix = matrix1 * matrix2;

            Matrix4 result = new()
            {
                Row1 = new Vector4(15250, 2125, 30016, 800),
                Row2 = new Vector4(65906, 7524, 34326, 2338),
                Row3 = new Vector4(59744, 7010, 11699, 2146),
                Row4 = new Vector4(41334, 6105, 11035, 3626)
            };

            Assert.AreEqual(matrix, result);
        }


        [TestMethod]
        public void MatrixTranspose()
        {
            Matrix4 transpose = matrix1.Transpose();

            Matrix4 result = new()
            {
                Row1 = new Vector4(3, 1, 0, 123),
                Row2 = new Vector4(5, 8, 10, 5),
                Row3 = new Vector4(9, 10, 3, 2),
                Row4 = new Vector4(12, 53, 48, 30)
            };

            Assert.AreEqual(transpose, result);
        }
    }
}