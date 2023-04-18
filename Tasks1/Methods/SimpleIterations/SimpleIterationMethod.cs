using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1.Methods.SimpleIterations
{
    public class SimpleIterationMethod : IMethods
    {
        readonly double[,]? matrixB;
        readonly double[]? matrixb;
        readonly double accuracy;
        readonly double[] firstApprox;
        public double[] Result { get; set; }
        double Norm { get; }
        public double Iterations { get; set; }
        public SimpleIterationMethod(double[,] matrixB, double[] matrixb, double accuracy, double[] firstApprox)
        {
            this.matrixB = matrixB;
            this.matrixb = matrixb;
            this.accuracy = accuracy;
            this.firstApprox = firstApprox;
            Norm = MatrixOperations.FindFirstMatrixNorm(matrixB);
        }

        public bool CheckConvergenceMethod(double firstNorm)
        {
            return firstNorm < 1;
        }

        public int FindInterationCount()
        {
            var iterations = 1;
            double eps;
            double firstNormApprox = FindFirstNormApprox();
            do
            {
                eps = Math.Pow(Norm, iterations) * 
                    firstNormApprox / (1.0 - Norm);
                iterations++;
            }
            while (eps > accuracy);
            return iterations;
        }

        public double FindFirstNormApprox()
        {
            double[] firstApproxResult = new double[firstApprox.Length];
            for (int i = 0; i < matrixB.GetLength(0); i++)
            {
                firstApproxResult[i] = 0;
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    firstApproxResult[i] += matrixB[i, j] * firstApprox[i];
                }
                firstApproxResult[i] += matrixb[i];

            }
            double result = Math.Abs(firstApprox[0] - firstApproxResult[0]);
            for (int i = 1; i < firstApproxResult.Length; i++)
            {
                if (Math.Abs(firstApprox[i] - firstApproxResult[i]) > result)
                    result = Math.Abs(firstApprox[i] - firstApproxResult[i]);
            }
            return result;
        }

        public void ReturnResult()
        {
            Result = new double[matrixB.GetLength(0)];
            Iterations = FindInterationCount();
            double[] currentValue = new double[matrixB.GetLength(0)];
            for (int i = 0; i < currentValue.Length; i++)
                currentValue[i] = 0.0;
            for (int k = 0; k < Iterations; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    Result[i] = 0;
                    for (int j = 0; j < 4; j++)
                        Result[i] += matrixB[i, j] * currentValue[j];
                    Result[i] += matrixb[i];
                    currentValue[i] = Result[i];
                }
            }
        }
    }
}
