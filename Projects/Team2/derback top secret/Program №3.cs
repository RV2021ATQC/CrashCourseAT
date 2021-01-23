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
                    Console.Write("length in the region of the range\n"+ userInput.ToString());
                }
                else if (userInput.Length > 80)
                {
                    Console.Write("length more than 80 characters long");
                }
                else Console.Write("String is empty");
            }

            public _String(int lan)///конструктор 2
            {
                int bufSize = lan;
                Stream inStream = Console.OpenStandardInput(bufSize);
                Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));
                if (userInput.Length <= bufSize && userInput.Length != 0)
                {
                    Console.WriteLine("Chars = " + userInput?.Length);
                }
                else if (userInput.Length > bufSize)
                {
                    Console.WriteLine("Length greater than " + lan+ " chars count");
                }
                else Console.WriteLine("String is empty");
            }

            public _String(int lan, string standartword)///конструктор 3
            {
                string sr1 = standartword;
                Console.WriteLine("Words: " + standartword+ standartword?.Length);
                Stream inStream = Console.OpenStandardInput(lan);
                Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, lan));
                if (userInput.Length <= lan && userInput.Length != 0)
                {
                    Console.WriteLine("Chars = " + standartword?.Length);
                }
                else if (userInput.Length > lan)
                {
                    Console.WriteLine("Length greater than " + lan + " chars count");
                }
                else Console.WriteLine("String is empty");
            }
        }

        static void InputInfo()//Метод для вводу і виводу
        {
            int c;
            string sdtr = "Default string ", a;
            Console.WriteLine("Constructor 1!");
            _String sd = new _String();
            Console.WriteLine("\nConstructor 2!");
            _String sg = new _String(1024);
            Console.WriteLine("Constructor 3!");
            _String sс = new _String(1024, sdtr);
            Console.WriteLine("Want to change the line?  1 = Yes / 2 = No");
            try
            {
                c = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                c = 2;
            }
            switch (c)
            {
                case 1:
                    Console.WriteLine("Enter new string: ");
                    a = Console.ReadLine();
                    sdtr = a;
                    Console.WriteLine("New string " + sdtr + " length " + sdtr?.Length);
                    break;
                case 2:
                    return;
                default: return;
            }
            Console.ReadKey();
        }

        static void Main(string[] args)///Main
        {
            InputInfo();
        }
    }
}
