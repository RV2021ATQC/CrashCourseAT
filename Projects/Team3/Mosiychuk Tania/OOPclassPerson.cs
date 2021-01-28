using System;

namespace OOPclassPerson
{
    class Person
    {
        public string Name;
        public int Age;
        public string Sex;
        public string MobileNumber;

        public string SetName()
        {
            Console.Write("Enter your changed name: ");
            Name = Console.ReadLine();
            return Name;
        }

        public int SetAge()
        {
            Console.Write("Enter your changed age: ");
            Age = int.Parse(Console.ReadLine());
            return Age;
        }

        public string SetSex()
        {
            Console.Write("Enter your changed sex: ");
            Console.WriteLine("For male enter 'M'\nFor female enter 'F' ");
            Sex = Console.ReadLine();
            switch (Sex)
            {
                case "M": Sex = "Male";
                    break;
                case "F": Sex = "Female";
                    break;
            }
            return Sex;
        }

        public string SetMobileNumber()
        {
            Console.WriteLine("Enter your changed mobile number: ");
            MobileNumber = Console.ReadLine();
            return MobileNumber;
        }

        public void PrintPerson()
        {
            Console.WriteLine($"Name: {Name}\nAge: {Age}\nSex: {Sex}\nMobile phone: {MobileNumber}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person Person1 = new Person();
            Person1.Name = "Anna";
            Person1.Age = 21;
            Person1.Sex = "Female";
            Person1.MobileNumber = "+380672121987";
            Person1.PrintPerson();

            Console.WriteLine($"\nChoose the category which you would like to change: \n\nName: Enter 1" + 
                              "\nAge: Enter 2\nSex: Enter 3\nMobile number: Enter 4");

            string Operation = Console.ReadLine();
            switch (Operation)
            {
                case "1": 
                    Person1.SetName();
                    Person1.PrintPerson();
                    break;
                case "2": 
                    Person1.SetAge();
                    Person1.PrintPerson();
                    break;
                case "3": 
                    Person1.SetSex();
                    Person1.PrintPerson();
                    break;
                case "4": 
                    Person1.SetMobileNumber();
                    Person1.PrintPerson();
                    break;
            }
            Console.ReadLine();
        }
    }
}
