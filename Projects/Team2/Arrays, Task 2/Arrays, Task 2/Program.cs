using System;

namespace Arrays__Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            Console.Write("Введiть кiлькiсть елементiв масиву: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введiть {0}-й элемент", i + 1);
                a[i] = int.Parse(Console.ReadLine());
            }

            for (int i = n - 1; i >= 0; i--)
            {
                Console.Write(" ");
            }
            Console.WriteLine("");
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    Console.Write("Парне : (" + a[i] + ")");
                }
                else if (a[i] % 2 != 0)
                {
                    Console.Write("Не парне : (" + a[i] + ")");
                }
                Console.Write(a[i] + "\t");
            }
            Console.ReadKey();
        }
    }
}
