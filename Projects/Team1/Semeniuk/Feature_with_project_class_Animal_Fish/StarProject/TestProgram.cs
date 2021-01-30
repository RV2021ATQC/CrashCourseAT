using System;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StarProject
{
    [TestFixture]
    public class TestProgram
    {
        [Test]
        [Retry(1)]
        public void TestSum2()
        {
            //Given
            var AnimalCollection = new List<Animals>();
            //попередньо введені дані
            AnimalCollection.Add(new Animals(1234.5, "red"));
            AnimalCollection.Add(new Animals(2020, "blue"));
            AnimalCollection.Add(new Animals(4321, "brown"));
            AnimalCollection.Add(new Animals(234, "yellow"));
            AnimalCollection.Add(new Fish(1234, "black", "river fish", "mutant"));
            AnimalCollection.Add(new Fish(2015, "white", "sea fish", "normal"));

            //When
            Collection.SortDySpecies(AnimalCollection);

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
        //}
        //public class MyDataClass
        //{
        //    public static IEnumerable TestCases
        //    {
        //        get
        //        {
        //            yield return new TestCaseData(12, 3).Returns(4);
        //            yield return new TestCaseData(12, 2).Returns(6);
        //            yield return new TestCaseData(12, 4).Returns(3);
        //        }
        //    }
        //}
    }
