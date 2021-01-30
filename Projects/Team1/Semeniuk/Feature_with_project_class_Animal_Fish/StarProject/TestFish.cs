using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    class TestFish
    {
        [Test]
        [Category("AnimalsТest")]
        public void TestGetAge()
        {
            //Given
            double year = 2010;
            var fish = new Fish(year, "yellow", "river fish", "big");
            int ExpectedValue = (int)(Convert.ToInt32(DateTime.Now.Year) - year);

            //When
            var ActualValue = fish.GetAge();

            //Then
            Console.WriteLine("TestGetAge() execution");
            Assert.AreEqual(ExpectedValue, ActualValue);
        }
        [Test]
        [Category("AnimalsТest")]
        public void TestVoice()
        {
            //Given
            var fish = new Animals();
            string ExpectedValue = String.Format("Voice: Ruf!!!");

            //When
            var ActualValue = fish.ToString();

            //Then
            Console.WriteLine("TestVoice() execution");
            Assert.IsTrue(ExpectedValue == ActualValue);
        }
    }
}
