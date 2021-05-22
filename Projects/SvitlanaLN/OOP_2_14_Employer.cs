/* Create an abstract base class Employer with a virtual function Print().
 Create three descendant classes: President, Manager, Worker.
 Redefine the Print () function to output information that matches each type of employee.*/


using System;

namespace OOP_2_14_Employer
{    
    abstract class Employer
    {
        public string Name { get; set; }
        public Employer(string name)
        {
            Name = name;
        }
        public virtual void Print()
        {
            Console.WriteLine($"There is no information about {Name}'s work in the company.");
        }
    }


    class President : Employer
    {
        public string Company { get; set; }
        public President(string name, string company): base(name)
        {
            Company = company;
        }
        public override void Print()
        {
            Console.WriteLine($"{Name} is a president of {Company}.");
        }
    }

    class Manager : Employer
    {
        public int Years { get; set; }
        public Manager(string name, int years) : base(name)
        {
            Years = years;
        }
        public override void Print()
        {
            Console.WriteLine($"{Name} is a manager with {Years} years of experience.");
        }
    }

    class Worker : Employer
    {
        public string Position { get; set; }
        public Worker(string name, string position) : base(name)
        {
            Position = position;
        }
        public override void Print()
        {
            Console.WriteLine($"{Name} is a worker on a position of {Position}.");
        }
    }


    class OOP_2_14_Employer
    {
        static void Main(string[] args)
        {
            President p1 = new President("Anna", "Treasury");
            p1.Print();                                      // вызов метода Print из класса President
            Manager m1 = new Manager("Tolya", 5);
            m1.Print();                                      // вызов метода Print из класса Manager
            Worker w1 = new Worker("Andriy", "specialist");  // вызов метода Print из класса Worker 
            w1.Print();
            Console.ReadKey();
        }
    }
}
