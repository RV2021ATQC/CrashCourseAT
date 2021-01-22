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

            
            Console.WriteLine("1.Santimeters to inches");
            Console.WriteLine("2.Inches to centimeters");
            int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Enter count of centimeters");
                        double b = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Count of inches : " + b/2.54);
                        break;
                    case 2:
                        Console.WriteLine("Enter count of inches");
                        double c = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Count of centimeters : " + c*2.54);
                        break;
                }
                break;
            }
         
        }
    }
}
