using System;

namespace _1Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int sum = 0;
            Console.Write("Enter number: ");
            a = Convert.ToInt32(Console.ReadLine());
            while (a > 0)
            {
                sum = sum + a % 10;
                a = a / 10;
            }
            Console.WriteLine($"Sum of numbers = {sum}");
        }
    }
}
