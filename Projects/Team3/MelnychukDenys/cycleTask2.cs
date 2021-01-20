using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a range of numbers: ");
            int range = Convert.ToInt32(Console.ReadLine());
            int sumOfOddNumbers = 1;
            for (int i = 3; i <= range; i += 2)
                sumOfOddNumbers += i;
            Console.WriteLine($"The sum of odd numbers in the range up to {range}: {sumOfOddNumbers}");
            Console.ReadKey();
        }
    }
}
