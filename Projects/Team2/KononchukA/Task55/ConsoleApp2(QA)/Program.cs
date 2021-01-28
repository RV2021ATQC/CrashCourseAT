using System;

namespace ConsoleApp2_QA_
{
    //Створити абстрактний базовий клас Employer (службовець) з віртуальною функцією Print ().
    //Створіть три класи нащадки: President, Manager, Worker. Перевизначите функцію Print ()
     //для виведення інформації, що відповідає кожному типу службовця.
    class Program
    {
        static void Main(string[] args)
        {
            President pre = new President("Obama", 35);
            pre.Print();
            Manager man = new Manager("John",27);
            man.Print();
            Worker wor = new Worker("Bob", 24);
            wor.Print();
        }
    }
}
