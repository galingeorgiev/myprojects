namespace MatrixUtils.Tests
{
    using Matrix.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FillMatrix
    {
        [TestMethod]
        public void FillMatrix_FillWithNEqualTo1()
        {
            int[,] expectedOutput = new int[,]
            {
                { 1 }
            };
            int[,] realOutput = MatrixUtils.FillMatrix(1);

            CollectionAssert.AreEqual(expectedOutput, realOutput, "Wrong answer with n = 1.");
        }

        [TestMethod]
        public void FillMatrix_FillWithNEqualTo5()
        {
            int[,] expectedOutput = new int[,]
            {
                { 1, 13, 14, 15, 16 },
                { 12, 2, 21, 22, 17 },
                { 11, 23, 3, 20, 18 },
                { 10, 25, 24, 4, 19 },
                { 9, 8, 7, 6, 5 }
            };
            int[,] realOutput = MatrixUtils.FillMatrix(5);

            CollectionAssert.AreEqual(expectedOutput, realOutput, "Wrong answer with n = 5.");
        }

        [TestMethod]
        public void FillMatrix_FillWithNEqualTo6()
        {
            int[,] expectedOutput = new int[,]
            {
                { 1, 16, 17, 18, 19, 20 },
                { 15, 2, 27, 28, 29, 21 },
                { 14, 31, 3, 26, 30, 22 },
                { 13, 36, 32, 4, 25, 23 },
                { 12, 35, 34, 33, 5, 24 },
                { 11, 10, 9, 8, 7, 6 }
            };
            int[,] realOutput = MatrixUtils.FillMatrix(6);

            CollectionAssert.AreEqual(expectedOutput, realOutput, "Wrong answer with n = 6.");
        }
    }
}