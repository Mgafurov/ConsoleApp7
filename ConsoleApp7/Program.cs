using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количестов строк в матрице: ");
        int numRows = int.Parse(Console.ReadLine());
        Console.Write("Введите количестов столбцов в матрице");
        int numCols = int.Parse(Console.ReadLine());

        //создаём матрицу заданного размера
        int[,] matrix = new int[numRows, numCols];

        //инициализируем генератор чисел
        Random random = new Random();

        //заполняем матрицу случайными числами
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = random.Next(1, 101);//генерируем случайное число от 1 до 100
            }
        }
        //Выводим матрицу на экран
        Console.WriteLine("Сгенерированная матрица: ");
        for (int i = 0;i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        //Вычисляем сумму элементов матрицы
        int sum = 0;
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                sum += matrix[i, j];
            }
        }
        //Выводим сумму на экран
        Console.WriteLine("Сумма элементов матрицы: " + sum);
        Console.ReadKey();
    }
}