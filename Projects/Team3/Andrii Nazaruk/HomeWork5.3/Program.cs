using System;
using static HomeWork5._3.Program;

namespace HomeWork5._3
{

          //"Розробити клас Person, який містить відповідні члени для зберігання:
          //імені, віку, статі і телефонного номера.
          //Напишіть функції-члени,
          //які зможуть змінювати ці члени даних індивідуально.Напишіть функцію-член Person :: Print (), яка виводить відформатовані дані про людину."
    class Program
    {
        class Person
        {
            public Person(string name,int age,string phoneNumber,string sexType)
            {
                this.age = age;
                this.phoneNumber = phoneNumber;
                this.name =name;
                this.sexType = sexType;
                                          
            }
            public string name { get; set; }
            public string phoneNumber { get; set; }
            public string sexType { get; set; }

            public int age { get; set;}
            public void GetInfo()
            {
                Console.WriteLine($"Name : {name}");
                Console.WriteLine($"Age : {age}");
                Console.WriteLine($"PhoneNumber : {phoneNumber}");
                Console.WriteLine($"SexType : {sexType}");
            }

            public void Print(string name,string sexType,string phoneNumber,int age)
            {
                this.phoneNumber = phoneNumber;
                this.name = name;
                this.age = age;
                this.sexType = sexType;
                Console.WriteLine("Changed Name : "+name);
                Console.WriteLine("Changed PhoneNumber : "+phoneNumber);
                Console.WriteLine("Changed SexType : "+sexType);
                Console.WriteLine("Changed age : "+age);
              
            }
        }
        static void Main(string[] args)
        {
            Person person1 = new Person("Andrii",30,"+3809430943430","Male");

            person1.GetInfo();
            person1.Print("Lena", "Female", "+380111111123", 25);        
        }
        

          
           
        
    }
}
