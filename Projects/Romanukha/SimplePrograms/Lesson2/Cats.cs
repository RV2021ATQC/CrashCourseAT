using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public class Cats : Animals
    {
        public Cats() {
            this.age = 7;
        }
        public Cats(int a, int b, int c) {
            base.age = a;
            base.speed =b;
            base.weight = c;
        }

        //переписали (override) метод move в нащадку 
        //тобто змінили поведінку нащадка - принцип поліморфізму
        public override int move(int a, int b)
        {
            Console.WriteLine("overriden method");
            return base.move(a, b)*2;
        }
    }
}
