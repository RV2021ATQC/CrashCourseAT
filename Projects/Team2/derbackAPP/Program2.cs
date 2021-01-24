using System;

namespace ConsoleAppOOP1
{
    class Program
    {
        public class Person
        {
            int count;
            string sexinfo;
            public string name = "Vetal";
            public int age = 18;
            public int sex = 1;
            public long telephonenumber = 0968484332;

            public void PersonPrint()
            {
                switch (sex)
                {
                    case 1:
                        sexinfo = "Man";
                        break;
                    case 2:
                        sexinfo = "Woman";
                        break;
                    default:
                        sexinfo = "Sex unassigned";
                        break;
                }
                Console.WriteLine($"Name: {name}\nAge: {age}\nSex: {sexinfo}\nTelephone: {telephonenumber}");
                Console.ReadKey();
            }
            public string SetName()
            {
                Console.WriteLine("Enter name: ");
                name = Console.ReadLine();
                return name;
            }
            public string SetAge()
            {
                Console.WriteLine("Enter age: ");
                age = Convert.ToInt32(Console.ReadLine());
                return age.ToString();
            }
            public string SetSex()
            {
                Console.WriteLine("Enter sex 1 = man/2 = woman: ");
                sex = Convert.ToInt32(Console.ReadLine());
                return sex.ToString();
            }
            public string SetTelephone()
            {
                Console.WriteLine("Enter telephone: ");
                telephonenumber = Convert.ToInt64(Console.ReadLine());
                return telephonenumber.ToString();
            }
        }
        static void Main(string[] args)
        {
            int count = 0;
            Person vetal = new Person();
            vetal.PersonPrint();
            Povtor:
            Console.WriteLine("Select operation: 1 change name / 2 change age / 3 change sex / 4 change telephone");
            count = Convert.ToInt32(Console.ReadLine());
            switch(count)
            {
                case 1:
                    vetal.SetName();
                    vetal.PersonPrint();
                    goto Povtor;
                case 2:
                    vetal.SetAge();
                    vetal.PersonPrint();
                    goto Povtor;
                case 3:
                    vetal.SetSex();
                    vetal.PersonPrint();
                    goto Povtor;
                case 4:
                    vetal.SetTelephone();
                    vetal.PersonPrint();
                    goto Povtor;
                default:
                    Console.WriteLine("Unknown operation");
                    vetal.PersonPrint();
                    goto Povtor;
            }
        }
    }
}
