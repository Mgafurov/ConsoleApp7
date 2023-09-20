using System;
using System.Threading;

class Program
{
    private const int Rows = 20; //кол-во строк
    private const int Columns = 40; //кол-во столбцов 
    private const int GenerationDelay = 200; //задержка между поколениями (в миллисекундах)
    private static bool[,] petriDash;//Чашка Петри
    private static Random random = new Random();

    static void Main()
    {
        InitializePetriDash();
        while (true)
        {
            Console.Clear();
            DislplayPetriDash();
            NextGeneration();
            Thread.Sleep(GenerationDelay);
        }
    }
    private static void InitializePetriDash()
    {
        petriDash = new bool[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                //случайным образом расставляем бактерии
                petriDash[i, j] = random.Next(2) == 1;
            }
        }
    }
    private static void DislplayPetriDash()
    {
        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; j++)
            {
                char cell = petriDash[i, j] ? '0' : ' ';
                Console.Write(cell);
            }
            Console.WriteLine();
        }
    }
    private static void NextGeneration()
    {
        bool[,] newPetriDash = new bool[Rows, Columns];

        for (int i = 0; i < Rows; ++i)
        {
            for (int j = 0; j < Columns; j++)
            {
                int neighbors = CountNeighbors(i, j);
                if (petriDash[i, j])
                {
                    //бактерия жива
                    newPetriDash[i, j] = neighbors >= 2 && neighbors <= 3;
                }
                else
                {
                    //бактерия мертва
                    newPetriDash[i, j] = neighbors == 3;
                }
            }
        }
        petriDash = newPetriDash;
    }
    private static int CountNeighbors(int x, int y)
    {
        int count = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i >= 0 && i < Rows && j >= 0 && j < Columns && !(i == x && j == y))
                {
                    if (petriDash[i, j])
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}