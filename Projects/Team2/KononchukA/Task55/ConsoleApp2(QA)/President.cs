using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_QA_
{
    public class President:Employer
    {
        public President(string name, int age) : base(name, age)
        {
            this.name = name;
            this.age = age;
        }
        public override void Print()
        {
            Console.WriteLine("President information ");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine("");
        }
    }
}
