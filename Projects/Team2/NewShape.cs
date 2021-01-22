using System;


namespace Quadrangle
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please, enter the desired width of the shape");

            int width = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter the desired height of the shape");

            int height = int.Parse(Console.ReadLine());

            if (width < 1 || height < 1)
            {
                {
                    Console.WriteLine("I'm sorry, but an invalid value is entered");
                }
            }
            if (width == 1)
            {
                int i = 0;
                while (i != height)
                {
                    Console.WriteLine("*");
                    i++;
                }
            } 
            else if (height == 1)
            {
                int i = 0;
                while (i != width)
                {
                    Console.Write("*");
                    i++;
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < width; i++)

                {
                    Console.Write('*');
                }

                Console.WriteLine();

                for (int i = 0; i < height - 2; i++)
                {
                    Console.Write('*');

                    for (int b = 0; b < (width - 2); b++)
                    {
                        Console.Write(' ');
                    }

                    Console.Write('*');

                    Console.WriteLine();
                }
                for (int i = 0; i < width; i++)
                {
                    Console.Write('*');
                }
                 Console.WriteLine();
            }
        }     
    }
}
