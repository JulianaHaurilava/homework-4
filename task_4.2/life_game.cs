using System;

namespace GameOfLife
{
    public class LifeSimulation
    {
        private int _heigth;
        private int _width;
        private bool[,] cells;

        /// <summary>
        /// Создаем новую игру
        /// </summary>
        /// <param name="Heigth">Высота поля.</param>
        /// <param name="Width">Ширина поля.</param>

        public LifeSimulation(int Heigth, int Width)
        {
            _heigth = Heigth;
            _width = Width;
            cells = new bool[Heigth, Width];
            GenerateField();
        }

        /// <summary>
        /// Перейти к следующему поколению и вывести результат на консоль.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Двигаем состояние на одно вперед, по установленным правилам
        /// </summary>
        private void Grow()
        {
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    int numOfGoodNeighbors = GetGoodNeighbors(i, j);
                    int numOfBadNeighbors = GetBadNeighbors(i, j);

                    if (numOfBadNeighbors >= 3 && numOfGoodNeighbors < 3 || numOfBadNeighbors < 3 && numOfGoodNeighbors >= 3)
                    {
                        cells[i, j] = !cells[i, j];
                    }
 
                }
            }
        }

        /// <summary>
        /// Подсчет количества клеток-убийц.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число клеток-убийц клеток.</returns>

        private int GetBadNeighbors(int x, int y)
        {
            int NumOfBadNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == true && (i == x && j != y || i != x && j == y)) NumOfBadNeighbors++;
                    }
                }
            }
            return NumOfBadNeighbors;
        }

        /// <summary>
        /// Подсчет количества клеток-родителей.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число клеток-родителей.</returns>
        /// 

        private int GetGoodNeighbors(int x, int y)
        {
            int NumOfGoodNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == true && i != x && j != y) NumOfGoodNeighbors++;
                    }
                }
            }
            return NumOfGoodNeighbors;
        }

        /// <summary>
        /// Нарисовать Игру в консоли
        /// </summary>

        private void DrawGame()
        {
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(cells[i, j] ? "x" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Инициализируем случайными значениями
        /// </summary>

        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }

    internal class Program
    {

        // Ограничения игры
        private const int Heigth = 10;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Дадим пользователю шанс увидеть, что происходит, немного ждем
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
