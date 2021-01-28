using System;

namespace Lesson2
{
    //для вищих рівнів ієрархії використовують абстрактні класи
    //дані класи можуть місти неабстракті методи
    //можливо один абстрактний клас наслідувати від іншого

    /*abstract*/ public class Plants : ICook
    {
        //якщо ми хочемо ініціалізувати об'єкт класу нащадка, то
        //ми мусимо перевизначити УСІ абстрактні методи. 
        //Неможливо створити об'єкт, якщо в класі ще існують абстракції
        //   abstract string getPageNum();
        public int Age
        { get; set; }

        public int height;
        public bool isEdible;



        public Food GetFood()
        {
            Console.WriteLine("It is your salad");
            return new Food();
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }
    }   
}