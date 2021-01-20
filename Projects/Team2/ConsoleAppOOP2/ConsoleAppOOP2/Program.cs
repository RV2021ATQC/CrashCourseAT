using System;
using System.IO;

namespace ConsoleAppOOP2
{
    class Program
    {
        class _String
        {
            string userInput = Console.ReadLine();
            public _String()///конструктор 1
            {
                if (userInput.Length <= 80&& userInput.Length != 0)
                {
                    Console.Write("Довжина в межаш діапазону\n"+ userInput.ToString());
                }
                else if (userInput.Length > 80)
                {
                    Console.Write("Довжина більша ніж 80 символів");
                }
                else if(userInput.Length == 0)
                    Console.Write("Рядок порожній");
            }

            public _String(int lan)///конструктор 2
            {
                int bufSize = lan;
                Stream inStream = Console.OpenStandardInput(bufSize);
                Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
                if (userInput.Length <= bufSize && userInput.Length != 0)
                {
                    Console.WriteLine("символів ="+userInput?.Length);
                }
                else if (userInput.Length > bufSize)
                {
                    Console.WriteLine("Довжина більша ніж "+lan+" символів");
                }
                else if (userInput.Length == 0)
                    Console.WriteLine("Рядок порожній");
            }

            public _String(int lan, string standartword)///конструктор 3
            {
                int bufSize = lan;
                string sr1 = standartword;
                Console.WriteLine("Words: " + standartword+ standartword?.Length);
                Stream inStream = Console.OpenStandardInput(bufSize);
                Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
                if (userInput.Length <= bufSize && userInput.Length != 0)
                {
                    Console.WriteLine("символів = " + standartword?.Length);
                }
                else if (userInput.Length > bufSize)
                {
                    Console.WriteLine("Довжина більша ніж " + lan + " символів");
                }
                else if (userInput.Length == 0)
                    Console.WriteLine("Рядок порожній");
            }
        }
        static void Main(string[] args)///Main
        {
            int c;
            string sdtr = "Рядок за замовчуванням ", a;
            Console.WriteLine("Конструктор 1!");
            _String sd = new _String();
            Console.WriteLine("\nКонструктор 2!");
            _String sg = new _String(1024);
            Console.WriteLine("Конструктор 3!");
            _String sс = new _String(1024,sdtr);
            Console.WriteLine("Бажаєте змінити рядок?  1 = так / 2 = ні");
            try
            {
                c = Convert.ToInt32(Console.ReadLine());
            }catch
            {
                c = 2;
            }
            switch(c)
            {
                case 1:
                    Console.WriteLine("Введіть новий рядок: ");
                    a = Console.ReadLine();
                    sdtr = a;
                    Console.WriteLine("Новий рядок " + sdtr + " розмір " + sdtr?.Length);
                    break;
                case 2:
                    return;
                    break;
                default: return;
                    break;
            }
            Console.ReadKey();
        }
    }
}
