using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1
{
    public abstract class Employer
    {
        public string Position { get; set; }        
        public string Name { get; set; }
        public int Age { get; set; }
        public Employer(string position,string name,int age)
        {
            Position=position;
            Name = name;
            Age = age;
        }
        public virtual void Print()
        {            
            Console.WriteLine($"Position in company is {Position}");
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Age : {Age}");
        }
    }
}
