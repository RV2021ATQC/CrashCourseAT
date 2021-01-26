using System;
using System.Collections.Generic;

using System.Text;

namespace Lesson2
{
    public class Cats : Animals  // клас Cat наслідується від батьківсього класу Animal - принцип ООП наслідування.
                                 // Клас нащадок успадковує від батьківського класу усі (protected + public) поля і методи.
    {
        public string voise;

        //конструктор без параметрів
        public Cats()
        {
            this.age = 7;
        }

        //конструктор з параметрами  можемо викликати будь з яких оголошених конструкторів
        public Cats(int a, int b, int c)
        {
            base.age = a;
            base.speed = b;
            base.weight = c;

            this.voise = "Meow!";
            //виклик статичного методу, що належить класу Animals
            Animals.increaseCountOfAnimals();
        }

        //переписали (override) метод move в нащадку 
        //тобто змінили поведінку нащадка - принцип поліморфізму
        public override int move(int a, int b)
        {
            Console.WriteLine("Call overriden method move() from the Cats class");
            return base.move(a, b) * 2;
        }
    }
}
