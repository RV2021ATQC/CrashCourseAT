using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace OOP_star
{
    [TestFixture]
    public class TestBuildings
    {
        [Test]
        public void Testserializer() {
            var Actual = new List<Building>();
            var adress = new AdressInfo("City", "Street");
            var Expected = new List<Building>();
            foreach (int _ in Enumerable.Range(0, 10))
            {
                Actual.Add(new Building(adress, new DateTime(new Random().Next(1960, 2020), 9, 15)));
                Actual.Add(new House(adress, new DateTime(new Random().Next(1960, 2020), 9, 15),
                    50, new Random().Next(-10, 20), 3));                
            }
            Expected = Program.JSONSerializer(Actual);

            Assert.AreEqual(JsonConvert.SerializeObject(Actual), JsonConvert.SerializeObject(Expected));
        }

        [Test]
        
        [TestCase(2000, ExpectedResult = 20)]
        [TestCase(2022, ExpectedResult = 0)]
        [TestCase(2020, ExpectedResult = 0)]
        [TestCase(2019, ExpectedResult = 1)]
        public int TestAge(int year)
        {
            var building = new Building(new AdressInfo("Kyiv, Khreschatik Street"),
                                            DateTime.Parse($"19/02/2005"));
            building.Comm_date = DateTime.Parse($"19/02/{year}");

            return building.Age;
        }

        [Test]
        //[TestCase()]
        public void Testconverter()
        {
            var Expected = new House();
            var Actual = House.ConvertToHouse(new Building());
            Assert.AreEqual(JsonConvert.SerializeObject(Actual), JsonConvert.SerializeObject(Expected));
        }

    }
    
}
