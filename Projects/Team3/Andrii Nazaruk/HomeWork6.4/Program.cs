using System;

namespace HomeWork6._4
{

    //Дано масив випадкових чисел в діапазоні від -20 до +20. Необхідно знайти позиції крайніх негативних елементів
    //(самого лівого негативного елементу і самого правого негативного елементу)
    //і впорядкувати елементи, що знаходяться між ними.
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] arr = new int[10];
            int right=0;
            int left=0;
            int tmp;
            int i, j;
            for (i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-20, 20);
                Console.Write($" {arr[i]} ");
            }
            Console.WriteLine();
            for (i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    left = i;
                    break;
                }
            }
            Console.WriteLine($"Left Index : {left}");
            Console.WriteLine($"Left Number : {arr[i]}");
            for (i = arr.Length-1; i >= 0; i--)
            {
                if (arr[i] < 0)
                {
                    right = i;
                    break;
                }
                
            }          
            
            Console.WriteLine($"Right index: {right}");
            Console.WriteLine($"Right Number : {arr[i]}");
            for (i = left; i <= right; i++)
            {
                for (j =right; j>=left; j--)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        tmp = arr[j + 1];
                        arr[j+1] = arr[j];
                        arr[j] = tmp;
                    }
                }

                Console.WriteLine($"arr[i] { arr[i]}");
            }
            
        }
    }
}


