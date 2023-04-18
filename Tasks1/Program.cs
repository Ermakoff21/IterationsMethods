using Tasks1;
using Tasks1.Methods.SimpleIterations;
using Tasks1.Methods.TheSeidelFirst;
using System.Windows.Input;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<int> methodsNum = new List<int>() { 1, 2 };
                Console.WriteLine("Введите номер метода, с помощью которого " +
                    "будет производить решение системы");
                Console.WriteLine("1.Метод простой итерации.");
                Console.WriteLine("2.Метод Зейделя(первый вариант)");
                var methodNum = Console.ReadLine();
                if(!methodsNum.Contains(Convert.ToInt32(methodNum)))
                {
                    Console.WriteLine("Неверно введен номер метода! Попробуйте еще раз.");
                    Console.WriteLine();
                    Console.ReadKey();
                    continue;
                }
                while (true)
                {
                    Console.WriteLine("Введите матрицы B и b из СЛАУ вида x = Bx + b, " +
                        "точность вычисления и начальное приближение.");
                    Console.WriteLine();
                    Console.Write("Размерность матрицы B: ");
                    var matrixSize = Console.ReadLine().Split('x');
                    var rows = Convert.ToInt32(matrixSize[0]);
                    var columns = Convert.ToInt32(matrixSize[1]);
                    double[,] matrixB = new double[rows, columns]; 
                    Console.WriteLine("Матрица B:");
                    for(int i = 0; i < rows; i++)
                    {
                        var matrixStr = Console.ReadLine()?.Split(' ');
                        for(int j = 0; j < columns; j++)
                        {
                            matrixB[i, j] = Convert.ToDouble(matrixStr[j]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Столбец b:");
                    double[] matrixb = new double[rows];
                    var bStr = Console.ReadLine()?.Split();
                    for (int i = 0; i < rows; i++)
                    {
                        matrixb[i] = Convert.ToDouble(bStr[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Начальное приближение:");
                    double[] firstApprox = new double[rows];
                    var firstApproxStr = Console.ReadLine()?.Split();
                    for (int i = 0; i < rows; i++)
                    {
                        firstApprox[i] = Convert.ToDouble(firstApproxStr[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Точность: ");
                    var accuracy = Convert.ToDouble(Console.ReadLine());
                    if(methodNum == "1")
                    {
                        SimpleIterationMethod simpleIterationMethod =
                        new SimpleIterationMethod(matrixB, matrixb, accuracy, firstApprox);
                        simpleIterationMethod.ReturnResult();
                        Console.WriteLine("Итераций: " + simpleIterationMethod.Iterations);
                        for (int i = 0; i < rows; i++)
                        {
                            Console.WriteLine($"x{i} = {simpleIterationMethod.Result[i]}");
                        }
                        break;
                    }
                    if(methodNum == "2") 
                    {
                        TheSeidelMethodFirst iterationMethod =
                        new TheSeidelMethodFirst(matrixB, matrixb, accuracy, firstApprox);
                        iterationMethod.ReturnResult();
                        Console.WriteLine("Итераций: " + iterationMethod.Iterations);
                        for (int i = 0; i < rows; i++)
                        {
                            Console.WriteLine($"x{i} = {iterationMethod.Result[i]}");
                        }
                        break;
                    }
                }
            }
        }
    }
}
