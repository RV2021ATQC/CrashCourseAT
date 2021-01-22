using System;

namespace Task2
{
    //Write a program that converts UAH to $, Є
    class Program
    {  
        static void Main(string[] args)
        {
            Console.Write("Input the amount that you want to transfer (in UAH): ");
            double Amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Choose the currency\nDollar - Enter D\nEuro - Enter E");
            string Currency = Console.ReadLine();
            switch (Currency)
            {
                case "D":
                    Amount *= 28.15;
                    break;
                case "E":
                    Amount *= 33.8;
                    break;
                default: Console.WriteLine("Attention! You you entered uncorrect currency!");
                    break;
            }
            Console.WriteLine($"Transferred amount is {Amount}");
            Console.ReadKey();
        }
    }
}
