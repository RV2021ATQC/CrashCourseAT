using NUnit.Framework;
using TransportCollection;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TransportCollectionTest
{
    public class Tests
    {
        [Test]
        public void TestSumPrice()
        {
            var b = new Bicycle();
            var b1 = new Bicycle();
            var b2 = new Bicycle();
            b1.Price = 5000; 
            b2.Price = 12000;
            long ExpectedValue = 17000;
            Console.WriteLine("TestSum() execution");
            Assert.IsTrue(b.SumPrice(b1, b2) == ExpectedValue);
        }
    }
}