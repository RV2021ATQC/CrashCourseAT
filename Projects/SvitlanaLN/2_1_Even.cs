using System;
using System.Collections.Generic;
using System.Text;
class Program
{
        static void Main(string[] args)
        {
            //enter integer number
            Console.WriteLine(@"Input number (int value): ");
            string inputString = Console.ReadLine();
            int number;
            while (!Int32.TryParse(inputString, out number)) 
                {
                Console.WriteLine(@"Could not convert '{0}' to an int. Input number (int value) again: ", inputString);
                inputString = Console.ReadLine();
                }
            Console.Write("Your number is: "+number);
            if (number % 2 == 0) Console.Write(". It is even number.");
            else Console.Write(". It is odd number.");
            Console.ReadKey();
        }
}

