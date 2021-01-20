using System;

namespace HomeWork2._3
{
    class Program
    {
        //3. Відомо, що 1 дюйм дорівнює 2.54 см. Розробити додаток, що переводять дюйми в сантиметри і навпаки. Діалог з користувачем реалізувати через систему меню.
        static void Main(string[] args)
        {
                                         
         while(true)
            {

            
            Console.WriteLine("1.Якщо ви хочете перевести сантиметри в дюйми нажмите 1");
            Console.WriteLine("2.Якщо ви хочете перевести дюйми в сантиметри нажмите 2");
            int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Введите количество сантиметров");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Количество дюймов : " + b/2.54);
                        break;
                    case 2:
                        Console.WriteLine("Введите количество дюймов");
                        double c = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Количество сантиметров : " + c*2.54);
                        break;
                }
                break;
            }
         
        }
    }
}
