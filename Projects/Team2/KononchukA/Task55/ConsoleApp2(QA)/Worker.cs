using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_QA_
{
    public class Worker:Employer
    {
        public Worker(string name,int age) : base(name, age)
        {
            this.name = name;
            this.age = age;
        }
        public override void Print()
        {
            Console.WriteLine("Worker information");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("");
        }
    }
}
