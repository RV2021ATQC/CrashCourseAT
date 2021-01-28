using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_QA_
{
    public abstract class Employer
    {
        public string name;
        public int age;
        public Employer(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
        }
    }
}
