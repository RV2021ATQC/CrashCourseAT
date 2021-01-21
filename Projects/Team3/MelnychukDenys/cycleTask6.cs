using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Line;
            Console.Write("Enter your numbers: ");
            Line = Console.ReadLine();
            string intermediateVariable = "";
            for (int i = 0; i < Line.Length; i++)
            {
                intermediateVariable += Line[i];
                intermediateVariable += " ";
            }
            int[] numbers = new int[Line.Length];
            string[] ss = intermediateVariable.Split(' ');
            int sum = 0;
            for (int i = 0; i < Line.Length; i++)
            {
                numbers[i] = int.Parse(ss[i]);
                sum += numbers[i];
            }
            Console.WriteLine($"The sum of digits from a string: {sum}");
            Console.ReadKey();
        }
    }
}
