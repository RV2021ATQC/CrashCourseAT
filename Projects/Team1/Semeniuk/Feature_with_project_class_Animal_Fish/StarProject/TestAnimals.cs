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
            Assert.AreEqual(ExpectedValue, ActualValue);
        }
        [Test]
        [Category("AnimalsТest")]
        public void TestVoice()
        {
            //Given
            var animal = new Animals();
            string ExpectedValue = String.Format("Voice: Ruf!!!");

            //When
            var ActualValue = animal.ToString();

            //Then
            Console.WriteLine("TestVoice() execution");
            Assert.IsTrue(ExpectedValue == ActualValue);
        }
    }
}
