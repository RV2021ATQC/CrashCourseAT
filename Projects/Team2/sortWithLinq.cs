using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace funSortArray
{
	class Program
	{
		/*Написати функцію, яка сортує масив  розмірністю 10 елементів за зростанням або за спаданням,
		в залежності від третього параметра функції.
		Якщо він дорівнює 1, сортування йде за спаданням, якщо 0, то по зростанню. 
		Перші 2 параметра функції - це масив і його розмір, третій параметр за замовчуванням дорівнює 1. 
		Реалізація за допомогою Ling.
		*/
		static void Main(string[] args)
		{
			Console.WriteLine("Size array: ");
			int size = Int32.Parse(Console.ReadLine());
			int[] array = new int[size];
			Random rand = new Random();
			Console.WriteLine("\nRandomly generated array: ");
			for (int y = 0; y < size; y++)
			{
				array[y] = rand.Next(1, 100);
				Console.Write(array[y] + " ");
			}
			Console.WriteLine("\n\nMode(0 or 1)");
			int mode = Int32.Parse(Console.ReadLine());
			Sort(array, mode);
			}
		public static void Sort(int[] array,  int mode)
		{
			
			var leng = from i in array
					   orderby i
					   select i;
			if (mode == 0)
			{
				foreach (int i in leng)
				{
					Console.Write(i + " ");
				}
				Console.ReadKey();
			}
			else if (mode == 1)
			{
				var reverse = leng.Reverse();
				foreach (int i in reverse)
				{
					Console.Write(i + " ");
				}
				Console.ReadKey();
			}
		}
		
	}
}
