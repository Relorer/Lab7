using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLLTests
{
    [TestClass()]
    public class SolverTests
    {
        private Solver solver = new Solver();
        private double accuracy = 0.1;

        [TestMethod()]
        public void SolveTest1()
        {
            var result = solver.Solve(Data.Test);
            var expected = Data.ExpectedTest;

            var sum = 0.0;

            for (int i = 0; i < Data.Test.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.Test.MatrixA.GetLength(1); j++)
                {
                    sum += Data.Test.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }

        [TestMethod()]
        public void SolveTest2()
        {
            var result = solver.Solve(Data.V1);
            var expected = Data.ExpectedV1;

            var sum = 0.0;

            for (int i = 0; i < Data.V1.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.V1.MatrixA.GetLength(1); j++)
                {
                    sum += Data.V1.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }

        [TestMethod()]
        public void SolveTest3()
        {
            var result = solver.Solve(Data.V1WithSpecialCodition);
            var expected = Data.ExpectedV1WithSpecialCodition;

            var sum = 0.0;

            for (int i = 0; i < Data.V1WithSpecialCodition.MatrixA.GetLength(0); i++)
            {
                for (int j = 0; j < Data.V1WithSpecialCodition.MatrixA.GetLength(1); j++)
                {
                    sum += Data.V1WithSpecialCodition.MatrixA[i, j] * result[j];
                }
            }

            Assert.IsTrue(Math.Abs(0 - sum) < accuracy, $"expected: {0} actually: {sum}");

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(Math.Abs(expected[i] - result[i]) < accuracy, $"expected: {expected[i]} actually: {result[i]}");
            }
        }
    }
}