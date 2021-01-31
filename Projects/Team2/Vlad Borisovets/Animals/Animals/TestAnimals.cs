using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Animals
{
	class TestAnimals
	{
		[Test]
		[Category("AnimalsTest")]
		//Get age test
		public void GetAgeTest()
		{
			//Given
			int ExpectedValue = 20;

			//When
			var ActualValue = Program.GetAge(2001);

			//Then
			Assert.AreEqual(ActualValue, ExpectedValue);
		}
		[Test]
		[Category("AnimalsTest")]
		//Is the list empty
		public void EmtyTest()
		{
			Assert.That(Program.animals, Is.Empty);
		}
		[Category("Regression")]
		[TestCase(2001, 20)]
		[TestCase(2005, 16)]
		[TestCase(2003, 18)]
		[TestCase(2008, 13)]
		[TestCase(2011, 10)]
		public void GetAgeTest2(int age, int expectedPrice)
		{
			// act

			int actualAge = Program.GetAge(age);

			// assert

			Assert.AreEqual(expectedPrice, actualAge);
		}
	}
	
	
}

