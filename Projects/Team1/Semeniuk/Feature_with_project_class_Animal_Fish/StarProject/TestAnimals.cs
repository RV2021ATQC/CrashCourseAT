using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    [TestFixture]
    public class TestAnimals
    {
        [Test]
        //[Category("Animals")]
        public void TestGetAge()
        {
            //Given
            double year = 2013.5;
            var animal = new Animals(year, "red");
            int ExpectedValue = Convert.ToInt32(DateTime.Now.Year) - (int)year;

            //When
            var ActualValue = animal.GetAge();

            //Then
            Console.WriteLine("TestGetAge() execution");
            Assert.IsTrue(ActualValue == ExpectedValue);
        }
    }
}
