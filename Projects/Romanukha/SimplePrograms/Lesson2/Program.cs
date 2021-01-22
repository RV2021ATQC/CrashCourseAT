using System;


namespace Lesson2
{
    class Program
    {

        //перезавантажені overload методи 
        public static string calculate(int a, int b = 2323)
        {
            return (a + b).ToString();
        }

        public static string calculate(string a, string b = "2323")
        {
            return a + b.ToString();
        }



        static void Main(string[] args)
        {
            //виклик перезавантажених методів
            calculate(3);
            calculate(3, 7);
            calculate("text", "text2");

            //створення об'єкту типу Animals
            Animals animal1 = new Animals(12, 7, 30);
            animal1.move(2, 4);

            //створення об'єкту типу Cats двома різними конструкторами, відповідно отримаємо
            //різну ініціалізацію і різні значення для age створених об'єктів
            Cats cat1 = new Cats(2,4,5);
            cat1.move(1, 2);

            Console.WriteLine($"cat1.age {cat1.age}");

            Cats cat2 = new Cats();
            Console.WriteLine($"cat2.age {cat2.age}");
        }
      
    }
}
