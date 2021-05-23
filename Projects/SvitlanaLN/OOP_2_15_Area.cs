/* Create an abstract base class with a virtual function -area.
 Create derivative classes: rectangle, circle, right triangle, trapezoid with its area functions. 
 To verify, determine the array of references to the abstract class, which are assigned addresses of various objects. 
 Trapezoidal area: S = (a + b) h / 2             */

using System;

namespace OOP_2_15_Area
{
    abstract class Figure
    {
        public string Name { get; set; }
        public Figure(string name) => Name = name;
        public virtual double Area() => 0;
        public virtual void Print() { }
    }


    class Rectangle : Figure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Rectangle(string name, double height, double width) : base(name)
        {
            Height = height;
            Width = width;
        }
        public override double Area() => Math.Round(Height * Width, 2);
        public override void Print() => Console.WriteLine($"The area of {Name} with height={Height} and width={Width} is {Area()}.");

    }

    class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(string name, double radius) : base(name) => Radius = radius;
        public override double Area() => Math.Round(Radius * Radius * Math.PI, 2);
        public override void Print() => Console.WriteLine($"The area of {Name} with radius={Radius} is {Area()}.");

    }

    class Right_triangle : Figure
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public Right_triangle(string name, double height, double width) : base(name)
        {
            Height = height;
            Width = width;
        }
        public override double Area() => Math.Round((Height * Width) / 2, 2);
        public override void Print() => Console.WriteLine($"The area of {Name} with height={Height} and width={Width} is {Area()}.");

    }

    class Trapezoid : Figure
    {
        public double Height { get; set; }
        public double Base1 { get; set; }
        public double Base2 { get; set; }
        public Trapezoid(string name, double height, double base1, double base2) : base(name)
        {
            Height = height;
            Base1 = base1;
            Base2 = base2;
        }
        public override double Area() => Math.Round((Height * (Base1 + Base2)) / 2, 2);
        public override void Print() => Console.WriteLine($"The area of {Name} with height={Height}, bases {Base1} and {Base2} is {Area()}.");

    }
    class OOP_2_15_Area
    {
        static void Main(string[] args)
        {
            Figure[] mas = { new Rectangle("rectangle", 3.40, 4.34), new Circle("circle", 1), new Right_triangle("right triangle", 36, 2.25), new Trapezoid("trapezoid", 36, 2.25, 25) };
            for (int i = 0; i < mas.Length; i++) 
            { 
                mas[i].Print();
            }
            Console.ReadKey();
        }
    }
}
