﻿using System;
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
        public void TestSortDySpecies()
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
            var ExpectedValue = $"The sorted fish from collection(by species) : 1234, black, river fish, mutant, 0,1 \r\nThe sorted fish from collection(by species) : 2015, white, sea fish, normal, 0,1 \r\n";

            //When
            var ActualValue = Collection.SortBySpecies(AnimalCollection);

            //Then
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
        [Test]
        [Retry(1)]
        public void TestPrintOlderThen()
        {
            //Given
            var field1 = "born_year";
            var field2 = "color";
            var field3 = "kind";
            var field4 = "species";
            var field5 = "weight";
            var older = 2;
            //попередньо введені дані
            var AnimalCollection = new List<Animals> 
            { 
                new Animals(1234.5, "red"), 
                new Animals(2020, "blue") ,
                new Animals(4321, "brown") ,
                new Animals(4234, "yellow") ,
                new Fish(2015, "white", "sea fish", "normal")
            };
            var ExpectedValue = $"Now {field1} = 1234,5. obj(1)\nNow {field2} = red. obj(1)\nNow {field3} = sea fish. obj(5)\nNow {field5} = 0,1. obj(5)\nNow {field1} = 2015. obj(5)\nNow {field4} = normal. obj(5)\nNow {field2} = white. obj(5)\n";

            //When
            var ActualValue = Collection.PrintOlderThen(AnimalCollection, older);

            //Then
            Assert.IsTrue(ActualValue == ExpectedValue);
        }
    }
}
