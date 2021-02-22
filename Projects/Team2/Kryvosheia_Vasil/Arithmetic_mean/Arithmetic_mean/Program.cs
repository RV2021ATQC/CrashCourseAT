using System;
// Напишіть програму, 
// яка обчислює середнє арифметичне двох чисел.
// Write a program 
// that calculates the arithmetic mean of two numbers.
namespace Arithmetic_mean
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers : ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            //Parse: Преобразует строковое представление числа
            //в эквивалентное 32-битовое знаковое целое число.
            //Parse: Converts the string representation of a number
            //to an equivalent 32-bit signed integer.

            Console.WriteLine("Arithmetic mean : ");
            Console.WriteLine((double)(a+b) / 2);
            Console.ReadKey();
            // Метод ReadKey() чтобы консольное окно,
            // после запуска программы,
            // сразу не исчезло.
            // ReadKey () method for the console window,
            // after starting the program,
            // it did not disappear immediately.
        }
    }
}
