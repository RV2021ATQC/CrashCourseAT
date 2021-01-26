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
				array[y] = rand.Next(1, 21);
				Console.Write(array[y] + " ");

			}
			Console.WriteLine("\n\nMode(0 or 1)");
			int mode = Int32.Parse(Console.ReadLine());
			mySort(array, size, mode);
		}
		public static void mySort(int[] a, int size, int mode = 1)
		{
			int x, i, j;
			if (mode == 0)
			{
				for (i = 0; i < size; i++)
				{
					x = a[i];
					for (j = i - 1; j >= 0 && a[j] > x; j--)
				    a[j + 1] = a[j];
					a[j + 1] = x;
				}
			}

			else if (mode == 1)
			{
				for (i = 0; i < size; i++)
				{
					x = a[i];
					for (j = i - 1; j >= 0 && a[j] < x; j--)
				    a[j + 1] = a[j];
					a[j + 1] = x;
				}
			}
			for (int y = 0; y < a.Length; y++)
			{
				Console.Write(a[y] + " ");
			};
			Console.ReadKey();
		}

	}
}
