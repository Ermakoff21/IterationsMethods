using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks1
{
    public class MatrixOperations
    {
        public static double[,] MatrixAdditionCalculate(List<double[,]> matrices, char operation)
        {
            double[,] resultMatrix = new double[matrices[0].GetLength(0), matrices[0].GetLength(1)];
            for(int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for(int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = 0;
                }
            }
            for(int i = 0; i < matrices.Count; i++)
            {
                if(resultMatrix.GetLength(0) != matrices[i].GetLength(0) &&
                    resultMatrix.GetLength(1) != matrices[i].GetLength(1))
                {
                    throw new Exception("Размерности складываемых матриц должны совпадать.");
                }
                for (int k = 0; k < matrices[i].GetLength(0); k++)
                {
                    for (int j = 0; j < matrices[i].GetLength(1); j++)
                    {
                        if(operation == '+') resultMatrix[k, j] += matrices[i][k, j];
                        if(operation == '-') resultMatrix[k, j] -= matrices[i][k, j];
                    }
                }
            }
            return resultMatrix;
        }
        public static double[,] MatrixMultiplicationCalc(double[,] matrix1, double[,] matrix2)
        {
            int rowsInMatrix1 = matrix1.GetLength(0);
            int columnsInMatrix1 = matrix1.GetLength(1);
            int rowsInMatrix2 = matrix2.GetLength(0);
            int columnsInMatrix2 = matrix2.GetLength(1);

            if (columnsInMatrix1 != rowsInMatrix2)
            {
                throw new ArgumentException("Для умножения матрицы число столбцов в первой " +
                    "матрицы должно совпадать с числом строк во второй матрице");
            }

            var result = new double[rowsInMatrix1, columnsInMatrix2];

            for (int i = 0; i < rowsInMatrix1; i++)
            {
                for (int j = 0; j < columnsInMatrix2; j++)
                {
                    for (int k = 0; k < columnsInMatrix1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }
        public static double[,] InverseMatrix(double[,] matrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);

            double[,] inverseMatrix = new double[n, n];
            double determinant = Determinant(matrix);

            if (determinant == 0)
            {
                throw new Exception("Матрица вырождена, обратной матрицы не существует.");
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double[,] minor = Minor(matrix, i, j);
                    inverseMatrix[j, i] = Math.Pow(-1, i + j) * Determinant(minor) / determinant;
                }
            }

            return inverseMatrix;
        }
        public static double Determinant(double[,] matrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);

            if (n == 1) return matrix[0, 0];
            else if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            else
            {
                double determinant = 0;
                for (int i = 0; i < n; i++)
                {
                    double[,] minor = Minor(matrix, 0, i);
                    determinant += matrix[0, i] * Math.Pow(-1, i) * Determinant(minor);
                }
                return determinant;
            }
        }
        public static double[,] Minor(double[,] matrix, int row, int column)
        {
            int n = (int)Math.Sqrt(matrix.Length);
            double[,] minor = new double[n - 1, n - 1];

            for (int i = 0, k = 0; i < n; i++)
            {
                if (i == row) continue;
                for (int j = 0, l = 0; j < n; j++)
                {
                    if (j == column) continue;
                    minor[k, l] = matrix[i, j];
                    l++;
                }
                k++;
            }
            return minor;
        }
        public static double FindFirstMatrixNorm(double[,] matrix)
        {
            double sumInRow = 0;
            double maxOfRows = 0;
            double rows = matrix.GetLength(0);
            double columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                    sumInRow += Math.Abs(matrix[i, j]);
                if (sumInRow > maxOfRows)
                    maxOfRows = sumInRow;
                sumInRow = 0;
            }
            return maxOfRows;
        }
        public static double[,] MultiplyMatrixByScalar(double[,] matrix, double multiplier)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] result = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * multiplier;
                }
            }
            return result;
        }
        public static double[,] Transpose(double[,] matrix) 
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] result = new double[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }
            return result;
        }
        public static double[,] ReturnIdentityMatrix(int rows, int columns)
        {
            double[,] identityMatrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j) identityMatrix[i, j] = 1;
                    else identityMatrix[i, j] = 0;
                }
            }
            return identityMatrix;
        }
        public static double[,] FindUpperTriangularMatrix(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            double[,] result = new double[rows, columns];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if (i - j < 0) result[i, j] = 0;
                    else result[i, j] = matrix[i, j];
                }
            }
            return result;
        }
        public static double[,] FindStrictlyLowerTriangularMatrix(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            double[,] result = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i - j < 0) result[i, j] = matrix[i, j];
                    else result[i, j] = 0;
                }
            }
            return result;
        }
    }
}
