using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your number to get factorial: ");
            int Number = Convert.ToInt32(Console.ReadLine());
            int i;
            int factorial = 1;
            for (i = 1; i <= Number; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"Factorial of number {Number}: {factorial}");
            Console.ReadKey();
        }
    }
}
