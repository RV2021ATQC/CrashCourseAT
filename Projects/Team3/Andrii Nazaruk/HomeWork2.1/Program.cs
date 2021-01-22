using System;

namespace HomeWork2._1
{
    class Program
    {

        //1.Розробити програму, яка виводить на екран горизонтальну лінію з символів.
        // Кількість символів, який використовувати символ, і яка буде лінія - вертикальна, або горизонтальна - вказує користувач.
        static void Main(string[] args)
        {

            Console.WriteLine("Enter count of symbol you wan't ");
            int CountOfSymbol = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter symbol what you wanna see");
            string Symbol = Console.ReadLine();
            Console.WriteLine("What line you wanna see");
            Console.WriteLine("1.Vertical");
            Console.WriteLine("2.Horizontal");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        for (int i = 0; i <= CountOfSymbol; i++)
                        {
                            Console.WriteLine(Symbol);
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < CountOfSymbol; i++)
                        {
                            Console.Write(Symbol);
                        }
                    }
                    break;
            }
        }
    }
}
