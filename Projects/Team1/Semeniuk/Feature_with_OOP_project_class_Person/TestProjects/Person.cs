using System;
using System.Collections.Generic;
namespace TestProjects
{
    public class Person
    {

        private int age;
        private string name;
        private string sex;
        private string number;

        public Person(int age, string name, string sex, string number)
        {
            this.age = age;
            this.name = name;
            this.sex = sex;
            this.number = number;
        }
        public void ChangeName(string name)
        {
            this.name = name;
        }
        public void ChangeSex(string sex)
        {
            this.sex = sex;
        }
        public void ChangeAge(int age)
        {
            this.age = age;
        }
        public void ChangeNumber(string number)
        {
            this.number = number;
        }
        public void PrintPerson()
        {
            Console.WriteLine($"Age is {age}, Name is {name}, Sex is {sex}, Phone number is {number}");
        }

    }
}
