using System;

namespace Task39
{
    //Write a program that displays the contents of the array in reverse.
    class Program
    {
        static void ReadMas(int[] mas, int NumberofEl)
        {
            for (int i = 0; i < NumberofEl; i++)
            {
                Console.Write($"Input the {i + 1}th element of array: ");
                mas[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        static void PrintMas(int[] mas, int NumberofEl)
        {
            for (int i = 0; i < NumberofEl; i++)
            {
                Console.Write($"{mas[i]} ");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Input the number of elements: ");
            int NumberEl = Convert.ToInt32(Console.ReadLine());

            int[] MasNumbers = new int[NumberEl];
            ReadMas(MasNumbers, NumberEl);
            Array.Reverse(MasNumbers);

            Console.WriteLine("\nInverted array: ");
            PrintMas(MasNumbers, NumberEl);
            Console.ReadKey();
        }
    }
}
