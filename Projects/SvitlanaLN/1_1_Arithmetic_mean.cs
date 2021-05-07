using System;

    public static class StringConversion
      { static int WaitInt(string name_var)
        {
            Console.WriteLine($"Input {name_var} int value: ");
            string inputString;
        label1:
            inputString = Console.ReadLine();
            try
            { return int.Parse(inputString); }
            catch
            {
                Console.WriteLine($"Could not convert '{inputString}' to an int. Input {name_var} int value again: ");
                goto label1;
            }
        }

        static void Main(string[] args)
        {
        int a = WaitInt("first");
        int b = WaitInt("second");
        Console.WriteLine("Arithmetic mean of two numbers: {0}", (a+b)/2.0);
        Console.ReadKey();
            }
    }

