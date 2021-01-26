using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

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

    [TestFixture]
    public class TestPlants
    {
        [Test]
        public void TestSum()
        {
            Assert.Pass();
            var plant = new Plants();
            int ExpectedValue = 5;
            Assert.IsTrue(plant.Sum(2, 3) == 5);
            Assert.Equals(plant.Sum(2, 3), ExpectedValue);
            Assert.IsFalse(ExpectedValue.ToString() == "1 should not be prime");
            Assert.IsFalse(ExpectedValue.ToString() != "1 should not be prime");
        }
    }
}

