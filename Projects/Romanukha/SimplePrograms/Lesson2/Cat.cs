using System;
using System.Xml.Serialization;

namespace Lesson2
{
    [Serializable]
    public class Cat : Animal  // клас Cat наслідується від батьківсього класу Animal - принцип ООП наслідування.
                                 // Клас нащадок успадковує від батьківського класу усі (protected + public) поля і методи.
    {
        [XmlElement()]
        public string voise;

        //конструктор без параметрів
        public Cat()
        {
            this.age = 7;
        }

        //конструктор з параметрами  можемо викликати будь з яких оголошених конструкторів
        public Cat(int a, int b, int c)
        {
            base.age = a;
            base.speed = b;
            base.weight = c;

            this.voise = "Meow!";
            //виклик статичного методу, що належить класу Animals
            Animal.increaseCountOfAnimals();
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
