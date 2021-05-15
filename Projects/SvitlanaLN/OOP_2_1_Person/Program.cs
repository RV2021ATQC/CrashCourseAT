/*Develop a Person class that contains the appropriate members for storage:
name, age, gender and telephone number.
Write member functions that can modify these data members individually.
Write a member function Person :: Print (), which displays formatted data about the person.*/


using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_2_1_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("SvitlanaLN",47,true);                      // new object
            person1.Print();


            //modify data members:

            Console.WriteLine("\r\nInput name (string value): ");                  
            person1.Name = Console.ReadLine();

            Console.WriteLine("\r\nInput age (int value) from 0 to 150: ");
            person1.Age = Console.ReadLine();

            Console.WriteLine("\r\nInput gender ( 0 - male, 1 - female):");
            person1.Female = Console.ReadLine();

            Console.WriteLine("\r\nInput telephone (string value): ");
            person1.Telephone = Console.ReadLine();

            person1.Print();
            Console.ReadKey();
        }

    }
}