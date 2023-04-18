using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using Tasks1.Methods.SimpleIterations;

namespace IterationMethods.Test
{
    [TestFixture]
    public class SimpleIterationTests
    {
        [Test]
        public void Test1()
        {
            double[] approx = new double[] { 0, 0, 0, 0 };
            double[,] firstMatrixB = new double[4, 4]
            {
                { 0.42, -0.32, 0.03, 0.00},
                { 0.11, -0.26, -0.36, 0.00},
                { 0.12, 0.08, -0.14, -0.24},
                { 0.15, -0.35, -0.18, 0.00}
            };
            double[] firstMatrixb = new double[4]
            {
                0.44, 1.42, -0.83, -1.42
            };
            double[] firstExpectedResult = new double[4]
            {
                0.078742, 1.207965, -0.259372, -1.784289
            };
            SimpleIterationMethod simpleIterationMethod =
                new SimpleIterationMethod(firstMatrixB, firstMatrixb, 0.001, approx);
            simpleIterationMethod.ReturnResult();
            var result = new double[firstMatrixb.Length];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(simpleIterationMethod.Result[i], 6);
            }
            Assert.AreEqual(firstExpectedResult, result);
        }

        [Test]
        public void Test2()
        {
            double[] approx = new double[] { 0, 0, 0, 0 };
            double[,] secondMatrixB = new double[4, 4]
            {
                { 0.08, -0.03, 0.00, -0.04},
                { 0.00, 0.31, 0.27, -0.08},
                { 0.33, 0.00, -0.07, 0.21},
                { 0.11, 0.00, 0.03, 0.58}
            };
            double[] secondMatrixb = new double[4]
            {
                -1.2, 0.81, -0.92, 0.17
            };
            double[] secondExpectedResult = new double[4]
            {
                -1.32503, 0.67886, -1.27501, -0.03334
            };
            SimpleIterationMethod simpleIterationMethod =
                new SimpleIterationMethod(secondMatrixB, secondMatrixb, 0.001, approx);
            simpleIterationMethod.ReturnResult();
            var result = new double[secondMatrixb.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(simpleIterationMethod.Result[i], 5);
            }
            Assert.AreEqual(secondExpectedResult, result);
        }
    }
}