using System;

namespace HomeWork_OOP_1
{
    class Program
    {
       //Створити абстрактний базовий клас Employer (службовець) з віртуальною функцією Print (). Створіть три класи нащадки:
       //President, Manager, Worker. Перевизначите функцію Print () для виведення інформації, що відповідає кожному типу службовця.
           
        static void Main(string[] args)
        {
            President president = new President("Andrii", "President", 40);
            Manager manager = new Manager("Anton", "Manager", 29);
            Worker worker = new Worker("Roman", "Worker", 23);
            worker.Print();
            Console.WriteLine("----------------");
            manager.Print();
            Console.WriteLine("----------------");
            president.Print();
        }
    }
}
