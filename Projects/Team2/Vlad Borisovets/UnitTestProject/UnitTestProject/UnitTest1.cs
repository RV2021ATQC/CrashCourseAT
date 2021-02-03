using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject
{
	public class UnitTest1
	{
		public IWebDriver driver;
		
        [OneTimeSetUp]
		public void StartTest()
		{
			driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}
		[OneTimeTearDown]
		public void EndTest()
		{
			driver.Quit();
		}
		[Test]
		public void TestMethod()
		{
			driver.Navigate().GoToUrl("https://naurok.ua/");
			Thread.Sleep(2000);
			driver.FindElement(By.CssSelector("#w1 > li:nth-child(2) > a")).Click();
			driver.FindElement(By.CssSelector("#studentloginform-login")).Click();
			driver.FindElement(By.Id("studentloginform-login")).SendKeys("vladb707@gmail.com");
			driver.FindElement(By.Id("studentloginform-password")).SendKeys("test_worked" + Keys.Enter);
			Thread.Sleep(2000);
			string url = "https://naurok.ua/student/dashboard";
			Assert.AreEqual(url, driver.Url);
		}

		
	}
}
