using System;
using System.Collections.Generic;
using System.Text;
//using NUnit.Framework;

namespace Lesson2
{
    public class Plants : ICook
    {
        public int Age
        { get; set; }

        public int height;
        public bool isEdible;

     //   abstract string getPageNum();

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


    //[TestFixture]
    //public class TestPlants
    //{
    //    [Test]
    //    public void TestSum()
    //    {
    //        Assert.Pass();
    //        var plant = new Plants();
    //        int ExpectedValue = 5;
    //        // Assert.IsTrue(plant.Sum(2, 3) == 5);
    //        //  Assert.Equals(plant.Sum(2, 3), ExpectedValue);
    //        //Assert.IsFalse(ExpectedValue.ToString() == "1 should not be prime");
    //        // Assert.IsFalse(ExpectedValue.ToString() != "1 should not be prime");
    //    }
    //}
}

