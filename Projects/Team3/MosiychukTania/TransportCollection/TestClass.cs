using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
namespace TransportCollection

{
    class TestClass
    {
        public TestClass()
        {
            [Test]
             void SortedListOfBicyclesWhichCheaperThan5000Uah()
            {
                List<Bicycle> bicycles = new List<Bicycle>();

                Bicycle bicycle1 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Alcatel", Price = 8000, Speed = 30, YearOfExploatation = 13 };
                Bicycle bicycle2 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Huawei", Price = 12000, Speed = 28, YearOfExploatation = 11 };
                Bicycle bicycle3 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Cannondale", Price = 6000, Speed = 29, YearOfExploatation = 29 };
                Bicycle bicycle4 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Discovery", Price = 17000, Speed = 25, YearOfExploatation = 25 };
                Bicycle bicycle5 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Huawei", Price = 21000, Speed = 12, YearOfExploatation = 22 };
                Bicycle bicycle6 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Kinetic", Price = 9000, Speed = 27, YearOfExploatation = 10 };
                Bicycle bicycle7 = new Bicycle { TypeOfTransport = "Bicycle", Mark = "Alcatel", Price = 12000, Speed = 20, YearOfExploatation = 14 };

                var result = bicycles.
                    OrderBy(x => x.Price >= 5000).ToList();

                Assert.NotNull(result);
            }


        }    
    }
}