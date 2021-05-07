using System;
using System.Collections.Generic;
using System.Text;
    class Program
    {
        const double i = 2.54;
        static double number;
        static string inputString;

        static double WaitDouble(string name_var)
        {
            Console.WriteLine();
            Console.WriteLine("Input count of {0} (double value): ",name_var);
            inputString = Console.ReadLine();        
            while (!Double.TryParse(inputString, out number))
            {
                Console.WriteLine("Could not convert '{0}' to an double. Input count of {1} (double value) again: ", inputString, name_var);
                inputString = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine("You entered {0} {1}.", inputString, name_var);
            return number;
        }


        static void Main(string[] args)
        {   label1:
            Console.WriteLine();
            Console.WriteLine("Convert centimeters to inches - press 1.");
            Console.WriteLine("Convert inches to centimeters - press 2.");
            Console.WriteLine("Exit from program - press 3.");
            switch (Console.ReadLine())
            {
                case "1":
                    WaitDouble("centimeters");
                    Console.WriteLine("It is {0} inches", Math.Round(number/i,2));
                    goto label1;
                case "2":
                    WaitDouble("inches");
                    Console.WriteLine("It is {0} centimeters", Math.Round(number * i, 2));
                    goto label1;
                case "3":
                    break;
                default:
                    Console.WriteLine("Make your choose!");
                    Console.WriteLine();
                    goto label1;
            }
        }
    }

