using System;

namespace Task21
{
    //The user enters a number from the keyboard, you need to turn it (number) and display it.
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input the number: ");
            string InputNum = Console.ReadLine();
            string result = "";
            foreach (char i in InputNum)
            {
                result = i + result;
            }
            Console.WriteLine($"Result is {result}");
            Console.ReadKey();
        }
    }
}
