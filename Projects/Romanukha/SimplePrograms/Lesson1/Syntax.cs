using System;
using System.Collections.Generic;


namespace Lesson1
{
    class Syntax
    {
        public static void Main(string[] args)
        {
            int a = 1 ;
            int b = 1 ;
            var result = a + b;
            a++;
            a += 23;
            a -= 34;

            result = a % b;



            float floatExample = 1.3f;

            string stringExample = "Simple string";

            char caracterVariable = 'C';

            bool isTrue = true;

            //isTrue = a <= b;
            //isTrue = a == b;

            //var variableExample = "45567";

            //DateTime currentDay = DateTime.Now;

            int[] intArray;


            intArray = new int[3] { 1, 2, 3 };

            int[,] Array2D = new int[4, 3] { {1,2,3},{4,5,6},{7,8,9 },{10,11,12} };


            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Console.WriteLine($"Array value {Array2D[i,j]}");
                }
                    
            }

            //Console.WriteLine("Array value " + intArray[0]);

            //Console.Write(stringExample);

            //Console.Write("  ");

            //Console.WriteLine("Enter your age");



            //if (isTrue)
            //{

            //}else if (!isTrue) {

            //}

            var fromConsole = Console.ReadLine();

            switch (fromConsole)
            {
                case "1":
                    Console.WriteLine("variable = 1");
                    break;
                case "2":
                    Console.WriteLine("variable = 2");
                    break;
                case "3":
                    Console.WriteLine("variable = 3");
                    break;
                case "4":
                    Console.WriteLine("variable = 4");
                    break;
           //     default:
         //           Console.WriteLine("variable by default");
          //          break;
            }



            //for (int i = 0; i <=2; i++)
            //{
            //    Console.WriteLine($"Array value {intArray[i]}");
            //}

            //List<int> numList = new List<int>();

            //numList.Add(2);
            //numList.Add(21);
            //numList.Add(22);
            //numList.Add(23);

            //numList.RemoveAt(2);

            //foreach (var iterator in numList)
            //{
            //    Console.WriteLine($"List value {iterator}");
            //}

            //var i = 10;
            //while (i > 1) {
            //    Console.WriteLine($"Iteration # {i}");
            //    i--;
            //};

            //do
            //{
            //    Console.WriteLine($"Iteration # {i}");
            //    i--;
            //} while (i > 1);

            Console.WriteLine($"Press any button to finish program");
            Console.ReadLine();

        }
    }
}
