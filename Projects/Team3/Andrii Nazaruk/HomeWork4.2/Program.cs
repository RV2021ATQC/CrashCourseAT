using System;

namespace HomeWork4._2
{
    class Program
    {
        //2. Написати програму, яка знаходить суму парних і суму непарних елементів масиву.
        static void Main(string[] args)
        {
            Random r = new Random();
            int []array = new int[10];
            
            int countOfPares=0;
            int countOfNotPares = 0;
            for(int i=0;i<array.Length;i++)
            {
                array[i] = r.Next(0, 100);
                Console.WriteLine($"arr[i]={array[i]}");
            }
            for(int i=0;i<array.Length;i++)
            {
                if(array[i]%2==0)
                {
                    countOfPares+=array[i];
                }
                else if(array[i]%2!=0)
                {
                    countOfNotPares += array[i];
                }
                
            }
            Console.WriteLine(countOfPares);
            Console.WriteLine(countOfNotPares);
            
        }
    }
}
