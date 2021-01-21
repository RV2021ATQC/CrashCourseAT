using System;

namespace _2Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int result=0;
            Console.Write("Enter your number: ");
            a = Convert.ToInt32(Console.ReadLine());
            while (a > 0)
            {
                result *= 10;
                result += a % 10;
                a /= 10;
            }
            Console.WriteLine($"Reversed number is {result}");
        }
    }
}
