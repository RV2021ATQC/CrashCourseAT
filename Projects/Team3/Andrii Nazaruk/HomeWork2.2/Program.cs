using System;

namespace HomeWork2._2
{
    class Program
    {
        //2. Дано натуральне число а(a<100). Напишіть програму, що виводить на екран кількість цифр в цьому числі і суму цих цифр
        static void Main(string[] args)
        {
            Random r = new Random();
            int Digit = r.Next(0, 100);
            Console.WriteLine("a = "+Digit);
            int firstDigit = Digit/10;
            int secondDigit = Digit % 10;
            int count;
            int summ;
            
            if(Digit>10 && Digit<100)
            {
                count = 2;
                summ = firstDigit + secondDigit;
                Console.WriteLine("FirstDigit = " + firstDigit);
                Console.WriteLine("FirstDigit = " + secondDigit);
                Console.WriteLine("Count : " +count);
                Console.WriteLine("Summ = " +summ);
            }
            else
            {
                Console.WriteLine("Digit have a less then 2 members");
            }
        }
    }
}
