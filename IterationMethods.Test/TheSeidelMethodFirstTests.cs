using NUnit.Framework;
using Tasks1.Methods.TheSeidelFirst;

namespace IterationMethods.Test
{
    [TestFixture]
    public class TheSeidelMethodFirstTests
    {
        [Test]
        public void Test1()
        {
            double[] approx = new double[] { 0, 0, 0};
            double[,] firstMatrixB = new double[3, 3]
            {
                { 0.017, 0.031, 0.000},
                { -0.017, 0.001, 0.006},
                { 0.011, -0.005, -0.008}
            };
            double[] firstMatrixb = new double[3]
            {
                -0.398, 1.081, 0.92
            };
            double[] firstExpectedResult = new double[3]
            {
                -0.3704, 1.0938, 0.9032
            };
            TheSeidelMethodFirst iterationMethod =
                new TheSeidelMethodFirst(firstMatrixB, firstMatrixb, 0.001, approx);
            iterationMethod.ReturnResult();
            var result = new double[firstMatrixb.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(iterationMethod.Result[i], 4);
            }
            Assert.AreEqual(firstExpectedResult, result);
        }

        [Test]
        public void Test2()
        {
            double[] approx = new double[] { 0, 0, 0 };
            double[,] firstMatrixB = new double[3, 3]
            {
                { 0.12, 0.32, -0.08},
                { 0.26, 0.46, -0.15},
                { 0.04, -0.18, 0.00}
            };
            double[] firstMatrixb = new double[3]
            {
                0.32, 0.14, 0.16
            };
            double[] firstExpectedResult = new double[3]
            {
                0.5334, 0.4902, 0.0931
            };
            TheSeidelMethodFirst iterationMethod =
                new TheSeidelMethodFirst(firstMatrixB, firstMatrixb, 0.001, approx);
            iterationMethod.ReturnResult();
            var result = new double[firstMatrixb.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(iterationMethod.Result[i], 4);
            }
            Assert.AreEqual(firstExpectedResult, result);
        }
    }
}
