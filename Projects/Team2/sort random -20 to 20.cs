using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mas = new int[20];
            var rnd = new Random();
            Console.WriteLine("Random Value = ");
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rnd.Next(-20, 20);
                Console.Write($" ({mas[i]}) ");
            }
            Console.WriteLine("\nRandom Value after sort = ");
            for (int i = 0; i <= mas.Length - 2; i++)
            {
                for (int j = i + 1; j <= mas.Length - 1; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            for (int i = 0; i < mas.Length - 1; i++)
            {          
                Console.Write(mas[i]);
                Console.ReadLine();
            }
        }
    }
}
