using System;

namespace HoumLabApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////Завдання 1
            Console.Write("введiть число 1: ");
            double s1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("введiть число 2: ");
            double s2 = Convert.ToDouble(Console.ReadLine());
            double sarif = ((s1 + s2) / 2);
            Console.WriteLine("середнє арифметичне = "+sarif + "\n\n");
            //////////////Завдання 2
            int dollar = 25, evro = 30;
            double sum;
            Console.Write("count of money: ");
            double count = Convert.ToDouble(Console.ReadLine());
            Console.Write("translate in : dollar = 1  evro = 2 :");
            double trans = Convert.ToDouble(Console.ReadLine());
            if (trans == 1)
            {
                sum = count / dollar;
                Console.WriteLine(count + " grivns = " + sum.ToString() + " dollars\nkurs " + dollar.ToString() + "\n\n");
            }
            if (trans == 2)
            {
                sum = count / evro;
                Console.WriteLine(count + " grivns = " + sum.ToString() + " evro\nkurs " + evro.ToString() + "\n\n");
            }
            //////////////Завдання 3 
            Console.WriteLine("To be or not to be \n /Shekespeare/\n\n");
            //////////////Завдання 4 
            Console.Write("введiть число для пiднесення до квадрату: ");
            double pow = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("{0} в квадратi = {1}", pow, Math.Pow(pow, 2)+"\n\n");
            //////////////Завдання 5
            double s , r;
            Console.Write("введiть число 1: ");
            double c1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("введiть число 2: ");
            double c2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("введiть число 3: ");
            double c3 = Convert.ToDouble(Console.ReadLine());
            s = (c1 + c2 + c3);
            r = (c1 - c2 - c3);
            Console.WriteLine("Сума = " + s.ToString() + "\nРiзниця = " + r.ToString());
            Console.ReadKey();
        }
    }
}
