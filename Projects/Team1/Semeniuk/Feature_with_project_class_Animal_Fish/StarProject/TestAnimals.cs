using NUnit.Framework;
using System;

namespace StarProject
{
    [TestFixture]
    public class TestAnimals
    {
        [Test]
        [Category("AnimalsТest")]
        public void TestGetAge()
        {
            //Given
            double year = 2013;
            var animal = new Animals(year, "red");
            int ExpectedValue = (int)(Convert.ToInt32(DateTime.Now.Year) - year);

            //When
            var ActualValue = animal.GetAge();

            //Then
            Console.WriteLine("TestGetAge() execution");
            Assert.IsTrue(ActualValue == ExpectedValue);
        }
        [Test]
        [Category("AnimalsТest")]
        public void TestVoice()
        {
            //Given
            var animal = new Animals();
            string ExpectedValue = "Ruf!!!";

            //When
            var ActualValue = animal.Voice();

            //Then
            Console.WriteLine("TestGetAge() execution");
            Assert.AreSame(ExpectedValue, animal.ToString());
        }
    }
}
