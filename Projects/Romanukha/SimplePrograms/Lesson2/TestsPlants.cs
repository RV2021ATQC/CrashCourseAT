using System;
using System.Collections;
using NUnit.Framework;

namespace Lesson2
{
    [TestFixture]
    public class TestPlants
    {
        [OneTimeSetUp]
        public void setupTests()
        {
            Console.WriteLine("setupTests()");
        }


        [SetUp]
        public void setup()
        {
            Console.WriteLine("setup()");
        }


        [Test]
        [Category("Smoke")]
        [Category("Regression")]
        [Repeat(3)]
        [Order(1)]
        public void TestSum()
        {
            //  Assert.Pass();
            var plant = new Plants();
            int ExpectedValue = 5;
            Console.WriteLine("TestSum() execution");
            Assert.IsTrue(plant.Sum(2, 3) == ExpectedValue);
          //  Assert.IsFalse(ExpectedValue.ToString() != "1 should not be prime");
            //Assert.IsFalse(ExpectedValue.ToString() != "1 should not be prime");
        }

        [Test]
        [Retry(4)]
        //[Ignore("Ignore this test until... something is fixed; URL to BugReport")]
        public void TestSum2()
        {
            //Given
            var plant = new Plants();
            int ExpectedValue = 5;

            //When
            var ActualValue = plant.Sum(2, 3);

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }

        [Category("Regression")]
        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }


        [OneTimeTearDown]
        public void cleanUp()
        {
            Console.WriteLine("cleanUp()");
        }

    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
}
