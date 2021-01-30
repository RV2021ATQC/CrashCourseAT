using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    class TestFish
    {
        //[Test]
        //[Category("FishТest")]
        //public void TestGetAge()
        //{
        //    //Given
        //    double year = 2010;
        //    var fish = new Fish(year, "yellow", "river fish", "big");
        //    int ExpectedValue = (int)(Convert.ToInt32(DateTime.Now.Year) - year);

        //    //When
        //    var ActualValue = fish.GetAge();

        //    //Then
        //    Console.WriteLine("TestGetAge() execution");
        //    Assert.AreEqual(ExpectedValue, ActualValue);
        //}
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
