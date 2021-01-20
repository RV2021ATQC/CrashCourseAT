using System;

namespace HomeWork4._4
{
    class Program
    {
        //4. Написати програму, яка знаходить в масиві найменше непарне число і показує його на екран.
        static void Main(string[] args)
        {
            int[] arr = new int[10];
            int minNotPareNumber = 0;
            Random r = new Random();
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(0, 100);
                Console.WriteLine(arr[i]);
            }
            for(int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i - 1] && arr[i] % 2 != 0)
                {
                    minNotPareNumber = arr[i];
                }
            }
            Console.WriteLine("Min notPare number : "+minNotPareNumber);
        }
    }
}
