using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количестов строк в матрице: ");
        int numRows = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов в матрице: ");
        int numCols = int.Parse(Console.ReadLine());
        //создаём первую матрицу и заполняем случайными числами 
        int[,] matrixA = GenerateRandomMatrix(numRows, numCols);
        //создаём вторую матрицу и заполняем случайными числами
        int[,] matrixB = GenerateRandomMatrix(numRows, numCols);
        //создаём матрицу для хранения результата сложения
        int[,] resultMatrix = new int[numRows, numCols];
        //выполняем сложение матриц 
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }
        //выводим матрицы на экран
        Console.WriteLine("Первая матрица: ");
        PrintMatrix(matrixA);
        Console.WriteLine("Вторая матрица: ");
        PrintMatrix(matrixB);
        Console.WriteLine("Результат сложения матриц: ");
        PrintMatrix(resultMatrix);
        Console.ReadKey();//чтобы консольное окно не закрылось сразу
    }
    //функция для генерации матрицы с случайными числами
    static int[,] GenerateRandomMatrix(int numRows, int numCols)
    {
        int[,] matrix = new int[numRows, numCols];
        Random random = new Random();
        for (int i = 0;i < numRows;i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = random.Next(1, 101);//генерируем случайные число от 1 до 100
            }
        }
        return matrix;
    }
    //функция для вывода матрицы на экран
    static void PrintMatrix(int[,] matrix)
    {
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}