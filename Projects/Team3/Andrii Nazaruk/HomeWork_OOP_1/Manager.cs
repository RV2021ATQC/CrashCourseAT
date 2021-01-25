using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1
{
    public class Manager:Employer
    {
        public Manager(string name, string position, int age) : base(position, name, age)
        {
            Name = name;
            Position = position;
            Age = age;
        }
        private string Description = "This is private description for";
        public override void Print()
        {
            Console.WriteLine($"{Description } {Position}");
            Console.WriteLine("Information about Manager : ");
            base.Print();
        }
    }
}
