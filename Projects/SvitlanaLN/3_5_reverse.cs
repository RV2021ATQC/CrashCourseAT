using System;

    class reverse
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"Input number (int value): ");
            string inputString = Console.ReadLine();
            int number;
            while (!Int32.TryParse(inputString, out number))
            {
                Console.WriteLine(@"Could not convert '{0}' to an int. Input number (int value) again: ", inputString);
                inputString = Console.ReadLine();
            }
            Console.WriteLine("Your number is: " + number);
            Console.WriteLine();

            int result =0;

            while (number > 0)
            {
                result = result*10+number % 10;
                Console.WriteLine($"Step1. Result is {result}");
                number = number/10;
                Console.WriteLine($"Step2. Number is {number}");
                Console.WriteLine();
            }
            Console.WriteLine($"Reversed number is {result}");
            Console.ReadKey();
        }
    }

