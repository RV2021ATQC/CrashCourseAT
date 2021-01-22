using System;


namespace Square
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your number: ");
            int Number = Convert.ToInt32(Console.ReadLine());
            double SqrtNumber = Math.Sqrt(Number);
            Console.WriteLine("Square of {0} is: {1}", Number, SqrtNumber);
            Console.ReadLine();
        }

    }
}

