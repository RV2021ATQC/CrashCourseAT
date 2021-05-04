using System;

    public static class StringConversion
    { 
        static void Main(string[] args)
        {
        //ввводимо кількість гривень ( інтежер )
        Console.WriteLine($"Input amount of grivnas (int value): ");
        string inputString;
        int grivna;
        label1:
            inputString = Console.ReadLine();
            try
            {  grivna=int.Parse(inputString); }
            catch
                 {
                 Console.WriteLine($"Could not convert '{inputString}' to an int. Input amount of grivnas (int value) again: ");
                 goto label1;
                 }

        // вводимо курс доллара ( дабл) 
        Console.WriteLine($"Input dollar exchange rate (double value): ");
        double rate;
        label2:
             inputString = Console.ReadLine();
             try
                  { 
                  rate = double.Parse(inputString);
                  }
             catch (FormatException)
                  {
                  Console.WriteLine($"Could not convert '{inputString}' to a double. Input dollar exchange rate (double value) again: ");
                  goto label2;
                  }
             if (rate<=0)
                  {
                  Console.WriteLine($"Dollar exchange rate '{inputString}' must be greater than zerro. Input dollar exchange rate (double value) again: ");
                  goto label2;
                  }

        // переводимо гривні в долари
        double dollar = Math.Round(grivna / rate, 2);
        Console.WriteLine($"You can buy {dollar} dollars");
        Console.ReadKey();
        }
    }

