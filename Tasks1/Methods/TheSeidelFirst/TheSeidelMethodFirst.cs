using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1.Methods.TheSeidelFirst
{
    public class TheSeidelMethodFirst : IMethods
    {
        readonly double[,] matrixB;
        readonly double[] matrixb;
        readonly double accuracy;
        readonly double[] firstApprox;
        public double[] Result { get; set; }
        double[] currentApprox { get; set; }
        public double Iterations { get; set; }
        double Norm { get; set; }
        public TheSeidelMethodFirst(double[,] matrixB, double[] matrixb, double accuracy, double[] firstApprox)
        {
            var rows = matrixB.GetLength(0);
            var columns = matrixB.GetLength(1);
            double[,] identityMatrix = new double[rows,columns];
            this.matrixB = matrixB;
            this.matrixb = matrixb;
            this.accuracy = accuracy;
            this.firstApprox = firstApprox;
            Norm = MatrixOperations.
                FindFirstMatrixNorm(FindMatrixF());
        }
        public bool CheckConvergenceMethod(double firstNorm)
        {
            return firstNorm < 1;
        }

        public double[,] FindMatrixF()
        {
            var rows = matrixB.GetLength(0);
            var columns = matrixB.GetLength(1);
            var identityMatrix = MatrixOperations.ReturnIdentityMatrix(rows, columns);
            var upperMatrix = MatrixOperations.FindUpperTriangularMatrix(matrixB);
            var lowerMatrix = MatrixOperations.FindStrictlyLowerTriangularMatrix(matrixB);
            return MatrixOperations.MatrixMultiplicationCalc(MatrixOperations.InverseMatrix(
                MatrixOperations.MatrixAdditionCalculate(
                    new List<double[,]>{identityMatrix, lowerMatrix},'-')),
                    upperMatrix);
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
            currentApprox = firstApproxResult;
            return firstApproxResult.Max();
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

        public void ReturnResult()
        {
            Iterations = FindInterationCount();
            var rows = matrixB.GetLength(0);
            var columns = matrixB.GetLength(1);
            for (int r = 0; r < Iterations - 1; r++)
            {
                for (int i = 0; i < rows; i++)
                {
                    var currentValue = 0.0;
                    for (int j = 0; j < columns; j++)
                    {
                        currentValue += matrixB[i, j] * currentApprox[j];
                    }
                    currentApprox[i] = currentValue + matrixb[i];
                }
            }
            Result = currentApprox;
        }
    }
}
