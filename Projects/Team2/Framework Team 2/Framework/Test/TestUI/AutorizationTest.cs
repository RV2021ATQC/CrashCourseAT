using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pages;
using Data;
using Framework.Data.User;

namespace Framework.Test
{
	[TestFixture]
	class AutorizationTest
	{
		public IWebDriver driver;
		[OneTimeSetUp]
		public void StartTest()
		{
			driver = new ChromeDriver(BrowserOption.BrowserSettings());
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}
		[OneTimeTearDown]
		public void EndTest()
		{
			driver.Quit();
		}
		[Test]
		public void AutorizationPageTest()
		{
			//Step
			AutorizationPage.AuthorizationPageTest(driver, User.GetUser());
			//Verefication
			Assert.AreEqual(driver.Url, AutorizationPage.loginPageVereficationUrl);
		}
	}
}
