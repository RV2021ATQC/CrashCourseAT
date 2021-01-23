using System;

namespace ConsoleAppOOP
{
    class Program
    {
        public class Person
        {
            string sexinfo;
            public string name;
            public int age;
            public int sex;
            public int telephonenumber;

            public Person(string a, int b, int c, long d)
            {
                name = "Nameless"; age = 18; sex = 1; telephonenumber = 0000000000;
            }

            public void PersonPrint(string name, int age, int sex, long telephonenumber)
            {
                switch(sex)
                {
                    case 1:
                        sexinfo = "Man";
                        break;
                    case 2:
                        sexinfo = "Woman";
                        break;
                    default: sexinfo = "Sex unassigned";
                        break;
                }
                Console.WriteLine($"Name: {name}\nAge: {age}\nSex: {sexinfo}\nTelephone: {telephonenumber}");
                Console.ReadKey();               
            }
        }

        static void Main(string[] args)
        {
            string a;
            int b, c;
            long d;
            Console.WriteLine("Enter name: ");
            a = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter sex 1 = man/2 = woman: ");
            c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter telephone: ");
            d = Convert.ToInt64(Console.ReadLine());
            Person jack = new Person(a,b,c,d);          
            jack.PersonPrint(a, b, c, d);
        }
    }
}
