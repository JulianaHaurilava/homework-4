using System;

namespace task_4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowNumber, columnNumber, sum = 0;
            Random randomizer = new Random();

            Console.WriteLine("Введите количество строк матрицы.");
            while (!int.TryParse(Console.ReadLine(), out rowNumber))
            {
                Console.WriteLine("Ошибка! Введите целое число.");
            }

            Console.WriteLine("Введите количество столбцов матрицы.");
            while (!int.TryParse(Console.ReadLine(), out columnNumber))
            {
                Console.WriteLine("Ошибка! Введите целое число.");
            }

            int[,] firstArray = new int[rowNumber, columnNumber];

            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    firstArray[i, j] = randomizer.Next(-100, 101);
                    Console.Write($"{ firstArray[i, j],4}");
                    sum += firstArray[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nСумма всех элементов матрицы: {sum}\n");


            Console.WriteLine("Для того, чтобы перейти ко второму заданию," +
                              " нажмите любую клавишу...\n");
            Console.ReadKey(true);


            int[,] secondArray = new int[rowNumber, columnNumber];
            int[,] resultArray = new int[rowNumber, columnNumber];

            for (int i = 0; i < rowNumber; i++)
            {
                Console.Write("|");
                for (int j = 0; j < columnNumber; j++)
                {
                    Console.Write($"{ firstArray[i, j],4}");
                }
                Console.Write(" | ");

                if (i == rowNumber / 2)
                {
                    Console.Write(" + ");
                }
                else Console.Write("   ");

                Console.Write(" |");
                for (int j = 0; j < columnNumber; j++)
                {
                    secondArray[i, j] = randomizer.Next(-100, 101);
                    Console.Write($"{ secondArray[i, j],4}");
                    
                }
                Console.Write(" | ");

                if (i == rowNumber / 2)
                {
                    Console.Write(" = ");
                }
                else Console.Write("   ");

                Console.Write(" |");
                for (int j = 0; j < columnNumber; j++)
                {
                    resultArray[i, j] = firstArray[i, j] + secondArray[i, j];
                    Console.Write($"{ resultArray[i, j],4}");
                }
                Console.WriteLine(" |");
            }
        }
    }
}
