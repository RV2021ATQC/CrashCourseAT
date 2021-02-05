using NUnit.Framework;
using TransportCollection;

namespace ConsoleApp2
{
    class ClassTest
    {
        [Test]
        public void GetAgeTest()
        {
            int ExpectedValue = 3;
            var ActualValue = TransportData.GetAge(2018);
            Assert.AreEqual(ActualValue, ExpectedValue);
        }
    }
}
