using System;

namespace HomeWork4._3
{
    class Program
    {
        //3. Написати програму, яка знаходить в масиві значення, що повторюються два і більше разів, і показує їх на екран.
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] array = new int[1000];
            int count = 0;         
            int repeatDigit = 0;

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(0, 1000);
                Console.WriteLine(array[i]);
            }

            for (int i = 1; i < array.Length; i++)
            {

                if (array[i] == array[i - 1])
                {
                    repeatDigit = array[i];
                    count++;
                    Console.WriteLine("Repeat numbers :" + repeatDigit);

                }
            }
           
            Console.WriteLine("Count of repeats : " + count);


            
        }
    }
}





