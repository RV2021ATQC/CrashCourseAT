using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input data about person(Age,name,sex,number)");
            int age = int.Parse(Console.ReadLine());
            string name = Console.ReadLine();
            string sex = Console.ReadLine();
            string number = Console.ReadLine();
            Person myObj = new Person(age, name, sex, number);
            Console.WriteLine("If you want to change something press \"y\"");
            while (Console.ReadLine() == "y")
            {
                Console.WriteLine("Choose what to change age(1),name(2),sex(3),numer(4)");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Input new count of age");
                        myObj.ChangeAge(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Input new count of Name");
                        myObj.ChangeName(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Input new count of Sex");
                        myObj.ChangeSex(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Input new count of Phone number");
                        myObj.ChangeNumber(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Nothing to change");
                        break;
                }
                Console.WriteLine("Do you still want to change something? Press \"y\"/\"n\"");
            }
            myObj.PrintPerson();
            Console.ReadKey();
        }
    }
}
