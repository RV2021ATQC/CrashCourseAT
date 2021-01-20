using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Overloading
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введiть число для вибору типу рiвняннь\n\nЛiнiйне рiвняння: 1\nКвадратне рiвняння: 2");
			double res = Convert.ToDouble(Console.ReadLine());
			if(res == 1)
			{
				Console.WriteLine("Введіть а: ");
			    double a = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Введіть b: ");
				double b = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("x = "+ F1(a, b));
				Console.ReadKey();
			}
			if(res == 2)
			{
				Console.WriteLine("Введіть а: ");
				double a = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Введіть b: ");
				double b = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Введіть c: ");
				double c = Convert.ToDouble(Console.ReadLine());
				F2(a, b, c);

			}
		}
		public static double F1(double a, double b)
		{
				return (-b) / a; ;
		}
		public static string F2(double a, double b, double c)
		{
			double x1, x2, d;
			string rez="";
			d = (b * b) - (4 * a * c);
			if (d > 0)
			{
				x1 = ((-b) + Math.Sqrt(d)) / (2 * a);
				x2 = ((-b) - Math.Sqrt(d)) / (2 * a);
				Console.WriteLine("x1 = " + x1 + "\n");
				Console.WriteLine("x2 = " + x2 + "\n");
				Console.ReadKey();
			}
			else if (d < 0)
			{
				
				Console.WriteLine("No roots" + d);
				Console.ReadKey();
			}
			else if (d == 0)
			{
				x1 = ((-b) + Math.Sqrt(d)) / (2 * a);
				Console.WriteLine("x1 = " + x1 + "\n");
				Console.ReadKey();
			}
			return rez;
		}
	}
}
