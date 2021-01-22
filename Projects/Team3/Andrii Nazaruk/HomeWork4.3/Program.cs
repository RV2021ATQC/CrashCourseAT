using System;

namespace HomeWork4._3
{
    class Program
    {
        //3. Написати програму, яка знаходить в масиві значення, що повторюються два і більше разів, і показує їх на екран.
        static void Main(string[] args)
        {
           
            
            int[] array = new int[8]{1,2,3,4,4,7,6,7};
            Array.Sort(array);
           
            int count = 0;         
            int repeatDigit = 0;

            for (int i = 0; i < array.Length; i++)
            {
                
                Console.WriteLine(array[i]);

            }
                   

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    count++;
                                     
                }                                            
            }
           
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == array[i - 1])
                {
                    repeatDigit = array[i];
                    Console.WriteLine($"Repeat members of array : {repeatDigit}");
                }
            }
            


            Console.WriteLine($"Counts of repeat: {count}");
            

           
            


            
        }
    }
}





