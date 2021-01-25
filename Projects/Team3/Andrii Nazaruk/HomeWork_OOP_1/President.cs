using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_OOP_1
{
    public class President : Employer
    {
        public President(string name,string position,int age):base(position,name,age)
        {
            Position = position;
            Name = name;
            Age = age;
        }
        private string Description = "This is private description for";
        public override void Print()
        {
            Console.WriteLine($"{Description} {Position}");
            Console.WriteLine("Information about President : ");
            base.Print();
        }

    }
      
      
}
