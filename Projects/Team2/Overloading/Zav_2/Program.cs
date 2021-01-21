using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zav_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter a valid number: ");
			double realNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("How many characters to leave after the comma?: ");
			double decimalPlaces = Convert.ToDouble(Console.ReadLine());
			double rez = funRealNumber(realNumber, decimalPlaces);
			Console.WriteLine(rez.ToString());
			Console.ReadKey();

		}
		public static double funRealNumber(double realNumber, double decimalPlaces)
		{
			double rez = Math.Round(realNumber, Convert.ToInt32(decimalPlaces));
			return rez;

		}
	}
}
