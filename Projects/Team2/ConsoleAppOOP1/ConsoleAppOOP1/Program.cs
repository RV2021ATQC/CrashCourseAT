using System;

namespace ConsoleAppOOP1
{
    class Program
    {
        public class Person
        {
            int count;
            string sexinfo;
            public string name = "Віталій";
            public int age = 18;
            public int sex = 1;
            public long telephonenumber = 0968484332;

            public void PersonPrint()
            {
                if (sex == 1)
                {
                    sexinfo = "Чоловік";
                }
                if (sex == 2)
                {
                    sexinfo = "Жінка";
                }
                else if(sex!=2&&sex!=1)
                    sexinfo = "Стать не визначена";
                Console.WriteLine("Iм'я: "+name+"\nВiк:"+ age + "\nСтать:" + sexinfo + "\nТелефон: " +telephonenumber);
                Console.ReadKey();
            }
            public string Name()
            {
                Console.WriteLine("Введіть ім'я: ");
                name = Console.ReadLine();
                return name;
            }
            public string Age()
            {
                Console.WriteLine("Введіть вік: ");
                age = Convert.ToInt32(Console.ReadLine());
                return age.ToString();
            }
            public string Sex()
            {
                Console.WriteLine("Введіть стать 1 = чоловік/2 = жінка: ");
                sex = Convert.ToInt32(Console.ReadLine());
                return sex.ToString();
            }
            public string Telephone()
            {
                Console.WriteLine("Введіть телефон: ");
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
            Console.WriteLine("Введіть операцію: 1 змінити ім'я / 2 змінити кількість років / 3 змінити стать / 4 змінити телефон");
            count = Convert.ToInt32(Console.ReadLine());
            if (count == 1)
            {
                vetal.Name();
                vetal.PersonPrint();
                goto Povtor;
            }
            if(count == 2)
            {
                vetal.Age();
                vetal.PersonPrint();
                goto Povtor;
            }
            if (count == 3)
            {
                vetal.Sex();
                vetal.PersonPrint();
                goto Povtor;
            }
            if (count == 4)
            {
                vetal.Telephone();
                vetal.PersonPrint();
                goto Povtor;
            }
            if(count <1||count>4)
            {
                Console.WriteLine("Операція відсутня");
                vetal.PersonPrint();
                goto Povtor;
            }          
        }
    }
}
