using System;

namespace Class_inheritance
{
    class Program
    {
        class Student
        {
            public string name;
            string fname;

            public Student(string name, string fname)
            {
                this.name = name;
                this.fname = fname;
            }
            public void Display()
            {
                Console.WriteLine($"Student {name}, {fname}");
            }
        }
        class Aspirant : Student
        {
            string aspirant;
            public Aspirant(string name, string fname, string aspirant) : base(name, fname)
            {
                this.aspirant = aspirant;
                Console.WriteLine($"Aspirant {name}, {fname}, {aspirant}");
            }
        }
        static void Main(string[] args)
        {
            Student p = new Student("Vito", "Skaletta");
            p.Display();
            Aspirant emp = new Aspirant("Tomas", "Angelo", "defense of candidate work");
            Console.Read();
        }
    }
}
