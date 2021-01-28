using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_QA_
{
    public class Manager:Employer
    {
        public Manager(string name, int age) : base(name, age)
        {
            this.name = name;
            this.age = age;
        }
        public override void Print()
        {
            Console.WriteLine("Manager information");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("");
        }
    }
}
