using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    class TestFish
    {
        [Test]
        [Category("FishТest")]
        [TestCase(1, ExpectedResult = 0.1)]
        [TestCase(10, ExpectedResult = 1)]
        [TestCase(20, ExpectedResult = 2)]
        [TestCase(70, ExpectedResult = 7)]
        public double DataDrivenTestFeed(double foodstuff)
        {
            //Given
            var fish = new Fish();

            //When
            double WeightIncrease = fish.Feed(foodstuff);

            //Then
            return WeightIncrease;
        }
        [Test]
        [Category("FishТest")]
        public void TestVoice()
        {
            //Given
            var fish = new Fish();
            string ExpectedValue = String.Format("Voice: Blop!!!");

            //When
            var ActualValue = fish.ToString();

            //Then
            Console.WriteLine("TestVoice() execution");
            Assert.IsTrue(ExpectedValue == ActualValue);
        }
    }
}
